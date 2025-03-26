import pandas as pd
import matplotlib.pyplot as plt
from io import StringIO

# ---------------------------------------------------------------------
# 1) Hardcoded CSV Data
# ---------------------------------------------------------------------
data = """StartTime,EndTime,DurationMinutes,SessionType
2/28/2025 7:55:38 AM,2/28/2025 7:56:38 AM,1,Work
3/4/2025 8:57:40 PM,3/4/2025 9:27:40 PM,30,Work
3/4/2025 9:27:40 PM,3/4/2025 9:32:40 PM,5,Rest
3/4/2025 9:32:40 PM,3/4/2025 10:02:40 PM,30,Work
3/5/2025 2:06:26 AM,3/5/2025 2:11:26 AM,5,Rest
3/5/2025 2:29:36 AM,3/5/2025 2:59:36 AM,30,Work
3/5/2025 6:18:23 PM,3/5/2025 6:23:23 PM,5,Rest
3/5/2025 6:23:42 PM,3/5/2025 6:53:42 PM,30,Work
3/5/2025 9:33:47 PM,3/5/2025 9:38:47 PM,5,Rest
3/5/2025 9:42:00 PM,3/5/2025 10:12:00 PM,30,Work
3/6/2025 1:38:52 AM,3/6/2025 1:43:52 AM,5,Rest
3/18/2025 6:33:45 PM,3/18/2025 7:03:45 PM,30,Work
3/18/2025 7:08:36 PM,3/18/2025 7:13:36 PM,5,Rest
3/18/2025 7:27:33 PM,3/18/2025 7:57:33 PM,30,Work
3/18/2025 8:00:52 PM,3/18/2025 8:05:52 PM,5,Rest
3/18/2025 8:51:02 PM,3/18/2025 9:21:02 PM,30,Work
3/18/2025 10:55:47 PM,3/18/2025 11:25:47 PM,30,Work
"""

# ---------------------------------------------------------------------
# 2) Create DataFrame from CSV string
# ---------------------------------------------------------------------
df = pd.read_csv(StringIO(data), parse_dates=['StartTime', 'EndTime'])

# Make sure they're datetime (parse_dates above typically handles this)
df['StartTime'] = pd.to_datetime(df['StartTime'])
df['EndTime']   = pd.to_datetime(df['EndTime'])

# Create a separate 'Date' column (just YYYY-MM-DD)
df['Date'] = df['StartTime'].dt.date

# ---------------------------------------------------------------------
# 3) Group by date to get total minutes (both Work + Rest)
# ---------------------------------------------------------------------
daily_summary = df.groupby('Date')['DurationMinutes'].sum()

# ---------------------------------------------------------------------
# 4) Prepare a function to plot a chosen month
# ---------------------------------------------------------------------
def plot_month(ax, summary_series, year, month):
    """
    ax            = a matplotlib Axes object
    summary_series= your daily totals (Pandas Series: index=Date, value=minutes)
    year, month   = the specific month we want to display
    """
    # Clear the old plot so we can redraw
    ax.clear()

    # Build the date range for the entire chosen month
    # Start of the month:
    start_date = pd.to_datetime(f"{year}-{month:02d}-01")

    # Next month's 1st day:
    if month == 12:
        next_month = pd.to_datetime(f"{year+1}-01-01")
    else:
        next_month = pd.to_datetime(f"{year}-{month+1:02d}-01")

    # All calendar days in [start_date, next_month - 1 day]
    all_days = pd.date_range(start=start_date, end=next_month - pd.Timedelta(days=1), freq='D')

    # Reindex the daily_summary to ensure every day in this month has a value (fill missing with 0)
    monthly_data = summary_series.reindex(all_days.date, fill_value=0)

    # Plot a simple bar chart
    ax.bar(monthly_data.index, monthly_data.values)

    # Format the chart
    ax.set_title(f"Daily Total Minutes - {year}-{month:02d}")
    ax.set_xlabel("Date")
    ax.set_ylabel("Minutes")

    # Optional: rotate the dates on the x-axis for readability
    # `plt.gcf()` = get current figure
    plt.gcf().autofmt_xdate()

# ---------------------------------------------------------------------
# 5) Keyboard event to move left/right through months
# ---------------------------------------------------------------------
# Let's track a global or external state for the current year/month
current_year = 2025
current_month = 3

def on_key(event):
    global current_year, current_month
    if event.key == 'left':
        # Move to previous month
        if current_month == 1:
            current_month = 12
            current_year -= 1
        else:
            current_month -= 1
        plot_month(ax, daily_summary, current_year, current_month)
        plt.draw()

    elif event.key == 'right':
        # Move to next month
        if current_month == 12:
            current_month = 1
            current_year += 1
        else:
            current_month += 1
        plot_month(ax, daily_summary, current_year, current_month)
        plt.draw()

# ---------------------------------------------------------------------
# 6) Main: create the figure, connect the key handler, show the first month
# ---------------------------------------------------------------------
fig, ax = plt.subplots()
fig.canvas.mpl_connect("key_press_event", on_key)

# Plot the initial month (March 2025, in this example)
plot_month(ax, daily_summary, current_year, current_month)

# Show the window
plt.show()
