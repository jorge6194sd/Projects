using Microsoft.EntityFrameworkCore;
using BudgetApp;

var builder = WebApplication.CreateBuilder(args);

// 1) Add Razor Pages
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation(); // optional but nice during dev

// 2) Register EF Core using the In-Memory database
builder.Services.AddDbContext<BudgetDbContext>(options =>
{
    options.UseInMemoryDatabase("BudgetDb");
});

// Build the app
var app = builder.Build();

// 3) Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// (Optional) If you want to view https://localhost:5001, keep this
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Map Razor Pages
app.MapRazorPages();

// (Optional) Add a "summary" endpoint for date-range queries
app.MapGet("/api/summary", async (DateTime start, DateTime end, BudgetDbContext db) =>
{
    var expenses = await db.Expenses
        .Where(e => e.Date >= start && e.Date <= end)
        .ToListAsync();

    var incomes = await db.Incomes
        .Where(i => i.Date >= start && i.Date <= end)
        .ToListAsync();

    decimal totalForecastedExpenses = expenses.Sum(e => e.ForecastedAmount);
    decimal totalActualExpenses = expenses.Sum(e => e.ActualAmount);
    decimal totalForecastedIncome = incomes.Sum(i => i.ForecastedAmount);
    decimal totalActualIncome = incomes.Sum(i => i.ActualAmount);

    var result = new
    {
        Start = start,
        End = end,
        TotalForecastedExpenses = totalForecastedExpenses,
        TotalActualExpenses = totalActualExpenses,
        TotalForecastedIncome = totalForecastedIncome,
        TotalActualIncome = totalActualIncome,
        NetForecasted = totalForecastedIncome - totalForecastedExpenses,
        NetActual = totalActualIncome - totalActualExpenses
    };

    return Results.Ok(result);
});

app.Run();
