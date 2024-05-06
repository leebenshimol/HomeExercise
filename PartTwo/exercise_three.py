def is_sorted_polyndrom(string: str) -> bool:
    str_last_index = len(string) - 1
    middle_index = int(str_last_index / 2)
    half_string = string[0:middle_index + 1]
    half_sorted = sorted(half_string)
    for index in range(len(half_sorted)):
        if half_sorted[index] != half_string[index]:
            return False
    for i, char in enumerate(string):
        if char != string[str_last_index - i]:
            return False
    return True
