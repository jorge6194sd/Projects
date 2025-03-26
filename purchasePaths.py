#!/usr/bin/env python3

def monthly_knapsack_purchase(items, base_budget=400):
    """
    Greedily buy as many items (by total cost) as possible each month,
    using leftover rollover money. Each month:
      1) total_available = leftover + base_budget
      2) find the subset of remaining items with the highest total cost
         that fits <= total_available (a 0-1 knapsack approach)
      3) remove those items, update leftover, increment month
      4) repeat until all items are purchased

    :param items: List of (item_name, cost)
    :param base_budget: Base monthly budget
    :return: A list of steps, where each step is
             (month_number, [items_bought], spent_this_month, leftover_after)
    """

    # Convert items list to a modifiable list of (name, cost)
    remaining_items = items[:]

    month = 1
    leftover = 0
    purchase_plan = []

    while remaining_items:
        # Calculate how much we can spend this month
        this_month_budget = leftover + base_budget
        
        # 1) Solve a subset-sum/knapsack to pick the combination of items
        #    that maximizes total cost <= this_month_budget.
        chosen_indices = knapsack_maximize_cost(remaining_items, this_month_budget)

        # If for some reason we can't buy anything (chosen_indices is empty),
        # that means all remaining items exceed the current month's budget
        # individually. We'll just buy none this month -> leftover grows.
        # But let's allow that scenario.  (Otherwise we'd get stuck.)
        if not chosen_indices:
            # That means every single item in remaining_items is over this_month_budget
            # or we got an empty solution from knapsack. We'll do:
            purchased_items = []
            spent = 0
        else:
            # Build the list of purchased items from chosen_indices
            purchased_items = [remaining_items[i] for i in chosen_indices]
            spent = sum(item[1] for item in purchased_items)
        
        # 2) Update leftover
        new_leftover = this_month_budget - spent

        # 3) Remove chosen items from remaining
        #    Sort chosen_indices descending so we can pop from the end safely
        for idx in sorted(chosen_indices, reverse=True):
            remaining_items.pop(idx)

        # Record this month's action
        purchase_plan.append((
            month,
            [itm[0] for itm in purchased_items],  # item names
            spent,
            new_leftover
        ))

        # Move on
        leftover = new_leftover
        month += 1

    return purchase_plan


def knapsack_maximize_cost(items, budget):
    """
    A 0-1 knapsack approach to choose a subset of 'items' whose total cost
    is <= budget, and that total cost is as large as possible.

    :param items: A list of (name, cost) tuples
    :param budget: The maximum sum of costs allowed
    :return: A list of indices (into 'items') that yields the maximum total cost
             without exceeding 'budget'.
    """

    # We'll implement a standard dynamic programming approach:
    # dp[i][c] = maximum cost achievable using items[0..i-1] with capacity c
    # We'll also track which items are chosen by storing "choice" info.

    n = len(items)
    costs = [item[1] for item in items]

    # dp array: (n+1) x (budget+1), each entry is the max cost achievable
    dp = [[0] * (budget + 1) for _ in range(n + 1)]

    # For reconstruction, store boolean "picked item i or not"
    choice = [[False] * (budget + 1) for _ in range(n + 1)]

    # Build up the DP
    for i in range(1, n + 1):
        item_cost = costs[i-1]
        for cap in range(1, budget + 1):
            # if we don't pick item i-1
            dp[i][cap] = dp[i-1][cap]
            # if we can pick item i-1
            if item_cost <= cap:
                alt = dp[i-1][cap - item_cost] + item_cost
                if alt > dp[i][cap]:
                    dp[i][cap] = alt
                    choice[i][cap] = True

    # dp[n][budget] is the maximum total cost we can achieve
    # Reconstruct which items are chosen
    chosen_indices = []
    w = budget
    for i in range(n, 0, -1):
        if choice[i][w]:
            # That means we took item i-1
            chosen_indices.append(i-1)
            w -= costs[i-1]

    return chosen_indices


# ------------------ EXAMPLE USAGE ------------------ #
if __name__ == "__main__":
    # Some sample items
    items_list = [
        ("Moccamaster", 360),
        ("Leather Jacket", 240),
        ("Wood Tool 1", 200),
        ("Wood Tool 2", 200),
    ]

    base_budget = 400

    plan = monthly_knapsack_purchase(items_list, base_budget)
    
    print("Purchase Plan (Greedy - Maximize Monthly Cost):")
    for (m, bought, spent, leftover) in plan:
        print(f"  Month {m}: Bought {bought}, Spent={spent}, Leftover={leftover}")
