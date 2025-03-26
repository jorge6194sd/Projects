#!/usr/bin/env python3

from itertools import combinations

def find_purchase_paths_with_rollover(items, base_budget=400):
    """
    Enumerate all possible ways (paths) to buy the given items
    when leftover money from each month rolls over to the next.

    :param items: List of (item_name, cost) tuples
    :param base_budget: The base monthly budget that gets added each month
    :return: A list of all possible purchase paths.
             Each path is a list of (month_number, [items_bought_that_month], spent, leftover).
    """
    all_paths = []

    def backtrack(remaining_items, month, leftover, current_path):
        """
        :param remaining_items: list of (name, cost) still to purchase
        :param month: current month (1-based index)
        :param leftover: how much money has rolled over to this month
        :param current_path: the list of month-by-month decisions so far
        """
        # If no remaining items, we've found a complete path
        if not remaining_items:
            # Store a copy of the path in our results
            all_paths.append(list(current_path))
            return

        # The total available this month = leftover + base budget
        this_month_budget = leftover + base_budget

        # We can also choose to buy *nothing* this month if we want to roll all money to next month
        # So let's handle that as one "subset" (cost=0, leftover unchanged but grows by base_budget next month).
        # However, logically, skipping the entire month means the leftover simply becomes
        # this_month_budget at the end of the month. We'll handle that scenario in the loop below
        # by including an empty subset or a direct conditional.

        # Generate all subsets of 'remaining_items' with total cost <= this_month_budget
        # We'll check combination lengths from 0 to len(remaining_items).
        # '0' means "buy nothing this month."
        n = len(remaining_items)
        for r in range(n+1):  # from 0 up to n
            for subset in combinations(remaining_items, r):
                subset_cost = sum(item[1] for item in subset)
                if subset_cost <= this_month_budget:
                    # Valid purchase for this month
                    # 1. Figure out next leftover
                    new_leftover = this_month_budget - subset_cost
                    # 2. Next month you get base_budget again, which will be added on top of new_leftover

                    # Build next remaining items
                    subset_set = set(subset)
                    next_remaining = [itm for itm in remaining_items if itm not in subset_set]

                    # Add this month's decision to path
                    # We'll store: (month#, [items_bought], spent_this_month, leftover_after_spending)
                    items_bought_names = [i[0] for i in subset]
                    current_path.append((month, items_bought_names, subset_cost, new_leftover))

                    # Recurse to next month
                    backtrack(next_remaining, month + 1, new_leftover, current_path)

                    # Backtrack
                    current_path.pop()

    # Kick off recursion: start Month 1 with leftover=0
    backtrack(items, month=1, leftover=0, current_path=[])
    return all_paths


# --------------- EXAMPLE USAGE --------------- #
if __name__ == "__main__":
    # Define your items as (Name, Cost)
    items_list = [
        ("Moccamaster", 360),
        ("Leather Jacket", 240),
        ("Wood Tool 1", 200),
        ("Wood Tool 2", 200),
    ]

    base_budget_per_month = 400

    # Get all possible purchase paths with rollover
    results_with_rollover = find_purchase_paths_with_rollover(items_list, base_budget=base_budget_per_month)

    # Print results
    print(f"Total possible purchase paths with rollover: {len(results_with_rollover)}\n")

    # You can limit how many paths to print if there's a huge number
    for idx, path in enumerate(results_with_rollover[:20], start=1):
        print(f"Path #{idx}:")
        for (month_num, bought_items, spent, leftover_after) in path:
            print(f"  Month {month_num}: Bought {bought_items}, Spent={spent}, Leftover_end_of_month={leftover_after}")
        print()
    
    # If there are more than 20 results, we won't print them all here.
    # You can remove the slicing [:20] to see every path.
