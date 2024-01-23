# .Net Cybersecurity Encryption Projects

This series of .Net projects focuses on building key cybersecurity encryption systems. Each project tackles different aspects of encryption.

## Project 1: MD5 Hashing System

Project 1 implements an MD5 hashing system with a built-in salt. Additionally, it includes a birthday attack simulation where the program calculates two strings that, when hashed using MD5 with the same salt, produce matching hash values.

## Project 2: Diffie Hellman Key Exchange Simulation

Project 2 is a Diffie Hellman key exchange simulation using AES. The program can perform encryption or decryption tasks with an arbitrary key. Run the program using:

```bash
dotnet run 1 2 3 4 5 6 7 8 9
Where:

128-bit IV in hex
g_e in base 10
g_c in base 10
N_e in base 10
N_c in base 10
x in base 10
�
�
m
o
d
 
 
�
g 
y
 modN in base 10
Encrypted message C in hex
Plaintext message P as a string
Project 3: RSA Implementation
Project 3 is an implementation of RSA using the Extended Euclidean algorithm to calculate suitable key values. The program can encrypt/decrypt given plaintext and ciphertext values. Run the program using:

bash
Copy code
dotnet run 1 2 3 4 5 6
Where:

�
�
p 
e
​
  in base 10
�
�
p 
c
​
  in base 10
�
�
q 
e
​
  in base 10
�
�
q 
c
​
  in base 10
Ciphertext in base 10
Plaintext message in base 10
