using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUE.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUE.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Twitter;

namespace NUE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddEntityFrameworkMySql()
                .AddDbContext<ApplicationDbContext>(options => options
                .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #region snippet_AddGoogle
            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];

                options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
                options.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");
                options.SaveTokens = true;

                options.Events.OnCreatingTicket = ctx =>
                {
                    List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList(); 

                    tokens.Add(new AuthenticationToken()
                    {
                        Name = "TicketCreated", 
                        Value = DateTime.UtcNow.ToString()
                    });

                    ctx.Properties.StoreTokens(tokens);

                    return Task.CompletedTask;
                };
            })
            #endregion
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                facebookOptions.SaveTokens = true;
                facebookOptions.Events.OnCreatingTicket = (context) =>
                {
                    
                    var picture = $"https://graph.facebook.com/{context.Principal.FindFirstValue(ClaimTypes.NameIdentifier)}/picture?type=large";
                    context.Identity.AddClaim(new Claim("Picture", picture));
                    return Task.CompletedTask;
                };
            })

            .AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
                twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                twitterOptions.SaveTokens = true;
                twitterOptions.RetrieveUserDetails = true;
                twitterOptions.ClaimActions.MapJsonKey("display-name", "name");
                twitterOptions.ClaimActions.MapJsonKey("id", "name");
                twitterOptions.ClaimActions.MapJsonKey("profile-image-url", "profile_image_url_https");
                twitterOptions.Events.OnCreatingTicket = (context) =>
                {
                    context.Options.ClaimActions.MapJsonKey("profile-image-url", "profile_image_url_https");
                    context.Options.ClaimActions.MapJsonKey("twitter:name", context.AccessToken);
                    context.Options.ClaimActions.MapJsonKey("twitter:secret", context.AccessTokenSecret);
                    context.Options.ClaimActions.MapJsonKey("twitter:id", context.UserId);
                    return Task.CompletedTask;
                };
            });

        services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Account/Manage");
                options.Conventions.AuthorizePage("/Account/Logout");
                options.Conventions.AuthorizePage("/MyClaims");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
