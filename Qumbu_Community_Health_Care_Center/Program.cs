using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//creating Default Roles
using (var scope = app.Services.CreateScope())
{
    var roleManager =

    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Nurse", "Doctor", "Counsellor", "Pathology", "Patient", "Unit-Manager" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))

            await roleManager.CreateAsync(new IdentityRole(role));
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Sibusiso";
    string lastName = "Moyikwa";
    string email = "sibusisomoyikwa@gmail.com";
    string password = "Sibu@123";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }

}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Thabo";
    string lastName = "Mazibuko";
    string email = "mazibukothabo@gmail.com";
    string password = "Thabo@123";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Nurse");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Siyolise";
    string lastName = "Tshangisa";
    string email = "tshangisasiyolise@gmail.com";
    string password = "Siyo@123";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Counsellor");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Abulele";
    string lastName = "Maguba";
    string email = "drmaguba@gmail.com";
    string password = "Abulele@123";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Doctor");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Asanda";
    string lastName = "Monki";
    string email = "monkiasanda@gmail.com";
    string password = "Asanda@123";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Unit-Manager");
    }

}

app.Run();

