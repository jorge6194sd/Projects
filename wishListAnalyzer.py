# debt_sorter.py

def sort_by_past_due_amount(debts):
    """
    Sorts debts by past due amount (least to most).
    :param debts: List of dictionaries representing debts.
    :return: Sorted list of debts.
    """
    return sorted(debts, key=lambda debt: debt['past_due_amount'])

def sort_by_due_date(debts):
    """
    Sorts debts by due date (earliest first).
    :param debts: List of dictionaries representing debts.
    :return: Sorted list of debts.
    """
    return sorted(debts, key=lambda debt: debt['due_date'])

def sort_by_minimum_payment(debts):
    """
    Sorts debts by minimum payment (smallest to largest).
    :param debts: List of dictionaries representing debts.
    :return: Sorted list of debts.
    """
    return sorted(debts, key=lambda debt: debt['minimum_payment'])

def sort_by_missed_payments(debts):
    """
    Sorts debts by number of consecutive missed payments (most missed first).
    :param debts: List of dictionaries representing debts.
    :return: Sorted list of debts.
    """
    return sorted(debts, key=lambda debt: -debt['missed_payments'])  # Negative for descending order

def sortAll(debts):
    """
    Sorts debts by applying all priority sorting methods in reverse order of importance.
    :param debts: List of dictionaries representing debts.
    :return: Fully sorted list of debts.
    """
    debts = sort_by_past_due_amount(debts)
    debts = sort_by_due_date(debts)
    debts = sort_by_minimum_payment(debts)
    debts = sort_by_missed_payments(debts)  # Most important
    return debts

def printDebts(debts):
    """
    Prints debts in a readable format.
    :param debts: List of dictionaries representing debts.
    """
    print(f"{'Debt':<15} {'Missed Payments':<15} {'Past Due Amount':<15} {'Minimum Payment':<15} {'Due Date':<10}")
    print("=" * 70)
    for debt in debts:
        print(f"{debt['name']:<15} {debt['missed_payments']:<15} {debt['past_due_amount']:<15} {debt['minimum_payment']:<15} {debt['due_date']:<10}")

# Example usage
if __name__ == "__main__":
    debts = [
        {'name': 'Credit Card A', 'missed_payments': 3, 'past_due_amount': 500, 'minimum_payment': 50, 'due_date': 30},
        {'name': 'Utility Bill B', 'missed_payments': 1, 'past_due_amount': 200, 'minimum_payment': 200, 'due_date': 3},
        {'name': 'Car Loan C', 'missed_payments': 2, 'past_due_amount': 1000, 'minimum_payment': 300, 'due_date': 15},
        {'name': 'Credit Card D', 'missed_payments': 0, 'past_due_amount': 0, 'minimum_payment': 25, 'due_date': 7},
    ]

    sorted_debts = sortAll(debts)
    printDebts(sorted_debts)
