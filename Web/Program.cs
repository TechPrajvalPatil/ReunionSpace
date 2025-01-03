using Infra;
using Infra.Repositories.Classes;
using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession(
    opt =>
    {
        opt.IdleTimeout = TimeSpan.FromMinutes(20);
        opt.Cookie.HttpOnly = true;
        opt.Cookie.IsEssential = true;
    }
    );
string scon = builder.Configuration.GetConnectionString("scon");
builder.Services.AddDbContextPool<Context>(
    opt => opt.UseLazyLoadingProxies().UseSqlServer(scon)
    );
builder.Services.AddScoped<IAdminRepo,AdminRepo>();
builder.Services.AddScoped<ICountryRepo,CountryRepo>();
builder.Services.AddScoped<IStateRepo,StateRepo>();
builder.Services.AddScoped<ICityRepo,CityRepo>();
builder.Services.AddScoped<ICompanyAdminRepo, CompanyAdminRepo>();
builder.Services.AddScoped<IMemberRepo, MemberRepo>();
builder.Services.AddScoped<IPendingMemberRepo, PendingMemberRepo>();
builder.Services.AddScoped<IAcceptedMemberRepo,AcceptedMemberRepo>();
builder.Services.AddScoped<IRejectedMemberRepo,RejectedMemberRepo>();
builder.Services.AddScoped<IEventRepo, EventRepo>();
builder.Services.AddScoped<IEventRegRepo, EventRegRepo>();
builder.Services.AddScoped<IPollRepo, PollRepo>();  
builder.Services.AddScoped<IPollOptionRepo, PollOptionRepo>();  
builder.Services.AddScoped<IFeedRepo, FeedRepo>();
builder.Services.AddScoped<IManageFeedRepo, ManageFeedRepo>();
builder.Services.AddScoped<IConnectionRepo, ConnectionRepo>();
builder.Services.AddScoped<ICourseDetRepo,CourseDetRepo>();
builder.Services.AddScoped<IMemberStatusRepo, MemberStatusRepo>();
builder.Services.AddScoped<IJobProfileRepo, JobProfileRepo>();
builder.Services.AddScoped<ISkillsRepo, SkillsRepo>();
builder.Services.AddScoped<IProfileRepo,  ProfileRepo>();

var app = builder.Build();
app.MapControllerRoute(
    name:"area",
    pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}"
    );
app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.UseSession();
app.Run();
