# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.

from exercise_one import num_len
from exercise_two import pythagorean_triplet_by_sum
from exercise_three import is_sorted_polyndrom
from exercise_four import numbers_info
def print_hi(name):
    # Use a breakpoint in the code line below to debug your script.
    print(f'Hi, {name}')  # Press Ctrl+F8 to toggle the breakpoint.


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print_hi('lee')
    print(num_len(1))
    pythagorean_triplet_by_sum(30)
    print(f"{is_sorted_polyndrom("אבגדגבא")}")
    numbers_info()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
