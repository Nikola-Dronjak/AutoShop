using AutoShop.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Intrinsics.X86;

namespace AutoShop.Infrastructure
{
    public class UserSeeder
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRole.Admin_Role))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin_Role));
                if (!await roleManager.RoleExistsAsync(UserRole.User_Role))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User_Role));


                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // Admins:
                var admin = await userManager.FindByEmailAsync("admin1@gmail.com");
                if (admin == null)
                {
                    var newAdminUser = new IdentityUser()
                    {
                        Id = "1001",
                        UserName = "Admin1",
                        NormalizedUserName = "ADMIN",
                        Email = "admin1@gmail.com",
                        NormalizedEmail = "ADMIN1@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 78",
                        PhoneNumberConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(newAdminUser, "Admin1!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin_Role);
                    }
                }

                // Users:
                var appUser1 = await userManager.FindByEmailAsync("user1@gmail.com");
                if (appUser1 == null)
                {
                    var user1 = new IdentityUser()
                    {
                        Id = "1",
                        UserName = "User1",
                        NormalizedUserName = "USER1",
                        Email = "user1@gmail.com",
                        NormalizedEmail = "USER1@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 79",
                        PhoneNumberConfirmed = true,
                    };
                    var result1 = await userManager.CreateAsync(user1, "User1!");
                    if (result1.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user1, UserRole.User_Role);
                    }
                }

                var appUser2 = await userManager.FindByEmailAsync("user2@gmail.com");
                if (appUser2 == null)
                {
                    var user2 = new IdentityUser()
                    {
                        Id = "2",
                        UserName = "User2",
                        NormalizedUserName = "USER2",
                        Email = "user2@gmail.com",
                        NormalizedEmail = "USER2@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 80",
                        PhoneNumberConfirmed = true,
                    };
                    var result2 = await userManager.CreateAsync(user2, "User2!");
                    if (result2.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user2, UserRole.User_Role);
                    }
                }

                var appUser3 = await userManager.FindByEmailAsync("user3@gmail.com");
                if (appUser3 == null)
                {
                    var user3 = new IdentityUser()
                    {
                        Id = "3",
                        UserName = "User3",
                        NormalizedUserName = "USER3",
                        Email = "user3@gmail.com",
                        NormalizedEmail = "USER3@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 81",
                        PhoneNumberConfirmed = true,
                    };
                    var result3 = await userManager.CreateAsync(user3, "User3!");
                    if (result3.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user3, UserRole.User_Role);
                    }
                }

                var appUser4 = await userManager.FindByEmailAsync("user4@gmail.com");
                if (appUser4 == null)
                {
                    var user4 = new IdentityUser()
                    {
                        Id = "4",
                        UserName = "User4",
                        NormalizedUserName = "USER4",
                        Email = "user4@gmail.com",
                        NormalizedEmail = "USER4@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 82",
                        PhoneNumberConfirmed = true,
                    };
                    var result4 = await userManager.CreateAsync(user4, "User4!");
                    if (result4.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user4, UserRole.User_Role);
                    }
                }

                var appUser5 = await userManager.FindByEmailAsync("user5@gmail.com");
                if (appUser5 == null)
                {
                    var user5 = new IdentityUser()
                    {
                        Id = "5",
                        UserName = "User5",
                        NormalizedUserName = "USER5",
                        Email = "user5@gmail.com",
                        NormalizedEmail = "USER5@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 83",
                        PhoneNumberConfirmed = true,
                    };
                    var result5 = await userManager.CreateAsync(user5, "User5!");
                    if (result5.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user5, UserRole.User_Role);
                    }
                }

                var appUser6 = await userManager.FindByEmailAsync("user6@gmail.com");
                if (appUser6 == null)
                {
                    var user6 = new IdentityUser()
                    {
                        Id = "6",
                        UserName = "User6",
                        NormalizedUserName = "USER6",
                        Email = "user6@gmail.com",
                        NormalizedEmail = "USER6@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 84",
                        PhoneNumberConfirmed = true,
                    };
                    var result6 = await userManager.CreateAsync(user6, "User6!");
                    if (result6.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user6, UserRole.User_Role);
                    }
                }

                var appUser7 = await userManager.FindByEmailAsync("user7@gmail.com");
                if (appUser7 == null)
                {
                    var user7 = new IdentityUser()
                    {
                        Id = "7",
                        UserName = "User7",
                        NormalizedUserName = "USER7",
                        Email = "user7@gmail.com",
                        NormalizedEmail = "USER7@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 85",
                        PhoneNumberConfirmed = true,
                    };
                    var result7 = await userManager.CreateAsync(user7, "User7!");
                    if (result7.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user7, UserRole.User_Role);
                    }
                }

                var appUser8 = await userManager.FindByEmailAsync("user8@gmail.com");
                if (appUser8 == null)
                {
                    var user8 = new IdentityUser()
                    {
                        Id = "8",
                        UserName = "User8",
                        NormalizedUserName = "USER8",
                        Email = "user8@gmail.com",
                        NormalizedEmail = "USER8@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 86",
                        PhoneNumberConfirmed = true,
                    };
                    var result8 = await userManager.CreateAsync(user8, "User8!");
                    if (result8.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user8, UserRole.User_Role);
                    }
                }

                var appUser9 = await userManager.FindByEmailAsync("user9@gmail.com");
                if (appUser9 == null)
                {
                    var user9 = new IdentityUser()
                    {
                        Id = "9",
                        UserName = "User9",
                        NormalizedUserName = "USER9",
                        Email = "user9@gmail.com",
                        NormalizedEmail = "USER9@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 87",
                        PhoneNumberConfirmed = true,
                    };
                    var result9 = await userManager.CreateAsync(user9, "User9!");
                    if (result9.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user9, UserRole.User_Role);
                    }
                }

                var appUser10 = await userManager.FindByEmailAsync("user10@gmail.com");
                if (appUser10 == null)
                {
                    var user10 = new IdentityUser()
                    {
                        Id = "10",
                        UserName = "User10",
                        NormalizedUserName = "USER10",
                        Email = "user10@gmail.com",
                        NormalizedEmail = "USER10@GMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "+381 61 123 456 88",
                        PhoneNumberConfirmed = true,
                    };
                    var result10 = await userManager.CreateAsync(user10, "User10!");
                    if (result10.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user10, UserRole.User_Role);
                    }
                }
            }
        }
    }
}
