import matplotlib.pyplot as plt
import numpy as np
from scipy import stats


def user_input_to_list() -> list:
    prompt = "Please enter a number here, enter -1 to stop -> "
    user_input = 0
    numbers_list = []
    while user_input != -1:
        user_input = input(prompt).strip()
        if user_input.replace('-', '').isnumeric():
            user_input = float(user_input)
            if user_input != -1:
                numbers_list.append(user_input)
    return numbers_list


def numbers_data() -> None:
    numbers_list = user_input_to_list()
    if len(numbers_list) == 0:
        print("No numbers were added - the list is empty")
    else:
        print(f"Original numbers list - > {numbers_list}")
        print(f"Numbers list after sort - > {sort_list(numbers_list)}")
        print(f"The average of the numbers -> {average(numbers_list)}")
        print(f"The amount of positive numbers -> {positive_numbers_amount(numbers_list)}")
        show_graphical_data(numbers_list)


def average(numbers_list: list) -> float:
    sum_numbers = 0
    for num in numbers_list:
        sum_numbers += num
    return sum_numbers / len(numbers_list)


def sort_list(numbers_list: list) -> list:
    copy_list = numbers_list.copy()
    copy_list.sort()
    return copy_list


def positive_numbers_amount(numbers_list: list) -> int:
    amount_of_positive = 0
    for num in numbers_list:
        if num > 0:
            amount_of_positive += 1
    return amount_of_positive


def show_graphical_data(numbers_list: list) -> None:
    x = np.array(range(1, len(numbers_list) + 1))
    y = np.array(numbers_list)
    slope, intercept, r, p, std_err = stats.linregress(x, y)

    def func(x):
        return slope * x + intercept

    model = list(map(func, x))

    plt.scatter(x, y)
    plt.plot(x, model)
    plt.show()

# def pearson_correlation(numbers_list: list) -> float:
#     return 0
