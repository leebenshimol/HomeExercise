def pythagorean_triplet_by_sum(sum_: int) -> None:
    max_a = int(sum_/3)
    max_b = int(sum_/2)
    amount_of_triplets = 0
    for a in range(1, max_a):
        for b in range(a + 1, max_b):
            c = sum_ - a - b
            if (a * a + b * b) == (c * c):
                print(f"{a} < {b} < {c}")
                amount_of_triplets += 1
    if amount_of_triplets == 0:
        print("no triplets exists for this sum")
