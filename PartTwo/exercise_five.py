import math


def reverse_n_pi_digits(n: int) -> str:
    pi_as_string = str(math.pi).replace('.', '')
    n_pi_digits = pi_as_string[0:n]
    return n_pi_digits[::-1]
