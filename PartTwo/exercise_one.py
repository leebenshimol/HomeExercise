from math import log10


def num_len(natural_number: int) -> float:
    return log10(natural_number) + 1
