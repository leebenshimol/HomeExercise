import math


def reverse_n_pi_digits(n: int) -> None:
    pi_as_string = str(math.pi)
    print(pi_as_string[0:n])
