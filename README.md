# .Net Cybersecurity Encryption Projects

This series of .Net projects focuses on building key cybersecurity encryption systems. Each project tackles different aspects of encryption.

## Project 1: MD5 Hashing System

Project 1 implements an MD5 hashing system with a built-in salt. Additionally, it includes a birthday attack simulation where the program calculates two strings that, when hashed using MD5 with the same salt, produce matching hash values.

## Project 2: Diffie Hellman Key Exchange Simulation

Project 2 is a Diffie Hellman key exchange simulation using AES. The program can perform encryption or decryption tasks with an arbitrary key. Run the program using:

```bash
dotnet run 1 2 3 4 5 6 7 8 9```

Where:

1. 128-bit IV in hex
2. g_e in base 10
3. g_c in base 10
4. N_e in base 10
5. N_c in base 10
6. x in base 10
7. g^y mod N in base 10
8. An encrypted message C in hex
9. A plaintext message P as a string

**## Project 3: RSA Implementation**
Project 3 is an implementation of RSA using the Extended Euclidean algorithm to calculate suitable key values. The program can encrypt/decrypt given plaintext and ciphertext values. Run the program using:

bash```
dotnet run 1 2 3 4 5 6
```
where: 
1. p_e in base 10
2. p_c in base 10
3. q_e in base 10
4. q_c in base 10
5. Ciphertext in base 10
6. Plaintext message in base 10
