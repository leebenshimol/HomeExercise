def numbers_info() -> None: #to do: change name of func
    user_input = int(input("insert the numbers you want, enter -1 to stop"))
    # to do / check input is good
    numbers_list = []

    while user_input != -1:
        numbers_list.append(user_input)
        user_input = int(input("another one: "))
    sum = 0
    amount_of_positive = 0
    for i in range(len(numbers_list)):
        sum += numbers_list[i]
        if numbers_list[i] > 0:
            amount_of_positive += 1
    avg = sum / len(numbers_list)
    numbers_list.sort()
    print(numbers_list)
    print(avg)
    print(amount_of_positive)