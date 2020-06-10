# Avast Coding Test

Implementation of the Avast Coding Test in June 2020.

## Instructions

1. Build `dotnet build`
2. Run Tests `dotnet vstest PrimeTests/bin/Debug/netcoreapp3.1/PrimeTests.dll`
3. Run Project `dotnet run --project Prime`

## Task
### Introduction
Write an application that takes numeric input (N) from a user and outputs a multiplication table of (N) prime numbers.
This should not take you more than a couple of hours. But the aim is NOT to see how much you can code in a given time,
so feel free to spend as much time as you want to highlight your level of coding.
You must put your code onto GitHub and we will review it from there.

### The requirements
1. This exercise must be written in C# using the .NET Core v2 or higher framework
2. Write your application with high unit test coverage
3. For the input and output you can use the console, a web page, or something else
4. Please write an algorithm to solve the prime number generation - do not use a library method to generate your primes
5. The user should input a whole number N, where is N is at least 1
6. The application