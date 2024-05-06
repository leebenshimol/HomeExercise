import math


def pythagorean_triplet_by_sum(sum_: int) -> None:
    max_a = int(sum_/3)
    max_b = int(sum_/2)
    for a in range(1, max_a):
        for b in range(a + 1, max_b):
            c = sum_ - a - b
            if (a * a + b * b) == (c * c):
                print(f"{a} < {b} < {c}")
    print("no triplets exists for this sum")