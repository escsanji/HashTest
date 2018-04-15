For this question, i dont have much experience in the encryption area thus assuming it is not about reverse engineering the SHA256 algorithms.

It does not solve the problem of collisions so if any 2 input messages produce the same hash, the latter one will be returned in the GET.

On multiple users, it is probably more practical to have a storage per user for storing the hash-to-input dictionary