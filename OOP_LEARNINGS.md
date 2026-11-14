# C# OOP Learnings

A quick reviewer for the concepts covered so far in the Simple Banking System.

> **Scope:** This document covers Phase 1 — Encapsulation and Phase 2 — Inheritance only. Abstraction, polymorphism, and interfaces are not included as completed topics.

## 1. Encapsulation and Data Protection

### Encapsulation

- **Term:** Encapsulation
- **Definition:** Encapsulation keeps an object's data protected and allows access through controlled properties and methods.
- **Short Example:**

```csharp
account.Deposit(1000m);
account.Withdraw(200m);
```

`BankAccount` controls how its balance changes instead of allowing outside code to assign to `Balance` directly.

### Basic Validation and Data Protection

- **Term:** Basic Validation and Data Protection
- **Definition:** Validation checks whether an operation is allowed before changing object data. Data protection prevents invalid direct changes to important state.
- **Short Example:**

```csharp
public bool Deposit(decimal amount)
{
	if (amount <= 0)
	{
		return false;
	}

	Balance += amount;
	return true;
}
```

`Withdraw()` also rejects invalid amounts and prevents the balance from becoming negative.

## 2. Access and Properties

### Access Modifiers

- **Term:** Access Modifiers (`public`, `private`, `protected`)
- **Definition:** Access modifiers control which code can use a type or member. `public` is widely accessible, `private` is accessible only in the declaring class, and `protected` is accessible in the declaring class and its derived classes.
- **Short Example:**

```csharp
public class BankAccount
{
	private List<BankAccount> _accounts = new();
	protected int InternalValue;
	public bool Deposit(decimal amount) { /* ... */ }
}
```

Prefer `private` unless a derived class genuinely needs direct access to a member.

### Properties

- **Term:** Properties (`get`, `set`, `private set`)
- **Definition:** Properties provide controlled access to an object's data. A `private set` lets other classes read a value but allows only the declaring class to change it directly.
- **Short Example:**

```csharp
public decimal Balance { get; private set; }
```

Other classes can read `account.Balance`, but they cannot write `account.Balance = 1000m`.

### Nullable Reference Types

- **Term:** Nullable Reference Types (`BankAccount?`)
- **Definition:** A `?` indicates that a reference may contain an object or `null`. Code should check for `null` before using the object.
- **Short Example:**

```csharp
BankAccount? account = bankService.GetAccountByNumber(accountNumber);

if (account is not null)
{
	Console.WriteLine(account.OwnerName);
}
```

## 3. Classes, Objects, and Methods

### Constructors

- **Term:** Constructor
- **Definition:** A constructor runs when an object is created and initializes the object's required starting state.
- **Short Example:**

```csharp
BankAccount account = new BankAccount(
	123456789,
	"Darryll Pajaganas");
```

The `BankAccount` constructor receives the account number and owner name.

### Constructor Chaining with `base`

- **Term:** Constructor Chaining (`base`)
- **Definition:** A derived-class constructor can call a base-class constructor with `base(...)`. This initializes the part of the object inherited from the parent class.
- **Short Example:**

```csharp
public SavingsAccount(
	int accountNumber,
	string ownerName,
	decimal interestRate)
	: base(accountNumber, ownerName)
{
	InterestRate = interestRate;
}
```

### Instance Methods

- **Term:** Instance Method
- **Definition:** An instance method belongs to an object and can use that object's state. It is called through an object variable.
- **Short Example:**

```csharp
BankAccount account = new BankAccount(1001, "Darryll");
account.Deposit(500m);
```

`Deposit()` and `Withdraw()` are instance methods because they modify a particular account.

### Static Methods

- **Term:** Static Method
- **Definition:** A static method belongs to the class instead of a particular object. It can be called using the class name.
- **Short Example:**

```csharp
Console.WriteLine(
	DisplayAccountInfo.GetAccountInfo(account));
```

`GetAccountInfo()` is static because it formats the account passed to it and does not need a `DisplayAccountInfo` object.

## 4. Inheritance

### Inheritance: Base and Derived Classes

- **Term:** Inheritance
- **Definition:** Inheritance allows a derived class to reuse accessible members from a base class. `BankAccount` is the base class, while `SavingsAccount` and `CheckingAccount` are derived classes.
- **Short Example:**

```csharp
public class SavingsAccount : BankAccount
{
	public decimal InterestRate { get; private set; }
}
```

A `SavingsAccount` can use inherited members such as `Deposit()`, `Withdraw()`, and `Balance`.

### Parent-Type References and Child Objects

- **Term:** Parent-Type Reference and Child Object
- **Definition:** A variable whose type is the parent class can refer to an object created from a child class. The reference can directly access members declared by the parent type.
- **Short Example:**

```csharp
BankAccount savingsAccount = new SavingsAccount(
	123456789,
	"Darryll Pajaganas",
	0.03m);

savingsAccount.Deposit(1000m);
```

The object is a `SavingsAccount`, but the reference is typed as `BankAccount`.

### IS-A Relationship

- **Term:** IS-A Relationship
- **Definition:** An IS-A relationship means a child type is a kind of its parent type. It is the relationship represented by inheritance.
- **Short Example:**

```csharp
SavingsAccount savingsAccount = new SavingsAccount(
	123456789,
	"Darryll Pajaganas",
	0.03m);

// A SavingsAccount IS-A BankAccount.
BankAccount account = savingsAccount;
```

`CheckingAccount` also IS-A `BankAccount`.

## 5. Design and Collaboration

### HAS-A Relationship

- **Term:** HAS-A Relationship
- **Definition:** A HAS-A relationship means one class contains or manages objects of another type. It is commonly represented by a field or collection.
- **Short Example:**

```csharp
public class BankService
{
	private List<BankAccount> _accounts = new();
}
```

`BankService` HAS-A collection of `BankAccount` objects.

### USES-A Relationship

- **Term:** USES-A Relationship
- **Definition:** A USES-A relationship means a class receives or uses another object to perform its work without owning that object's whole lifecycle.
- **Short Example:**

```csharp
public static string GetAccountInfo(BankAccount account)
{
	return $"Account Number: {account.AccountNumber}";
}
```

`DisplayAccountInfo` USES-A `BankAccount` to create display text.

### Object Collaboration

- **Term:** Object Collaboration
- **Definition:** Object collaboration happens when objects work together by calling each other's public methods or passing references to one another.
- **Short Example:**

```csharp
BankService bankService = new BankService();
BankAccount account = new SavingsAccount(1001, "Darryll", 0.03m);

bankService.AddAccount(account);
DisplayAccountInfo.DisplayAccountByNumber(bankService, 1001);
```

`Program`, `BankService`, `BankAccount`, and `DisplayAccountInfo` each contribute to the operation.

### Separation of Concerns (SoC)

- **Term:** Separation of Concerns (SoC)
- **Definition:** Separation of concerns keeps different kinds of work in different parts of the program. Banking rules, account management, and display formatting are separated here.
- **Short Example:**

```text
BankAccount          -> banking data and behavior
BankService          -> account collection management
DisplayAccountInfo   -> account formatting and display
```

### Single Responsibility Principle (SRP)

- **Term:** Single Responsibility Principle (SRP)
- **Definition:** SRP says a class should have one main responsibility or one reason to change. Each class in the project focuses on a related task.
- **Short Example:**

```csharp
account.Deposit(1000m);                         // BankAccount
bankService.AddAccount(account);               // BankService
DisplayAccountInfo.GetAccountInfo(account);    // UI formatting
```

### DRY (Don't Repeat Yourself)

- **Term:** DRY (Don't Repeat Yourself)
- **Definition:** DRY means keeping common logic in one reusable place instead of copying it throughout the program. Inheritance and service methods help reduce repeated code.
- **Short Example:**

```csharp
public class SavingsAccount : BankAccount { }
public class CheckingAccount : BankAccount { }
```

Both account types reuse `Deposit()`, `Withdraw()`, and the common account properties from `BankAccount`.

### Method Extraction

- **Term:** Method Extraction
- **Definition:** Method extraction moves a focused piece of logic into a named method. This makes code easier to read, reuse, and test.
- **Short Example:**

```csharp
public static void DisplayAccountByNumber(
	BankService bankService,
	int accountNumber)
{
	BankAccount? account =
		bankService.GetAccountByNumber(accountNumber);

	if (account is not null)
	{
		Console.WriteLine(GetAccountInfo(account));
	}
}
```

Account lookup and formatting are given clear method names instead of being repeated in `Program`.

## Phase 3 — Abstraction

### Abstraction

- **Term:** Abstraction
- **Definition:** Abstraction exposes essential behavior while hiding unnecessary implementation details. The common account rules are defined in `BankAccount`, while account types provide their own type-specific behavior.
- **Short Example:**

```csharp
public abstract class BankAccount
{
	public abstract string GetAccountType();
}
```

### Abstract Class

- **Term:** Abstract Class
- **Definition:** An abstract class cannot be instantiated directly. It can provide shared members and serve as a base class for derived types.
- **Short Example:**

```csharp
public abstract class BankAccount
{
}
```

### Abstract Method

- **Term:** Abstract Method
- **Definition:** An abstract method has no body in the base class. Concrete derived classes must provide its implementation.
- **Short Example:**

```csharp
public abstract string GetAccountType();
```

### Concrete Class

- **Term:** Concrete Class
- **Definition:** A concrete class is a non-abstract class that can be instantiated. It must implement inherited abstract members.
- **Short Example:**

```csharp
public class SavingsAccount : BankAccount
{
	public override string GetAccountType()
	{
		return "Savings Account";
	}
}
```

### `abstract` Keyword

- **Term:** `abstract` Keyword
- **Definition:** The `abstract` keyword declares a class that cannot be instantiated or a method that must be implemented by a derived class.
- **Short Example:**

```csharp
public abstract class BankAccount
{
	public abstract string GetAccountType();
}
```

### `override` Keyword

- **Term:** `override` Keyword
- **Definition:** The `override` keyword supplies the implementation of an inherited abstract method or replaces an inherited virtual method.
- **Short Example:**

```csharp
public override string GetAccountType()
{
	return "Checking Account";
}
```

### Constructor in Abstract Classes

- **Term:** Constructor in an Abstract Class
- **Definition:** An abstract class can have a constructor. A derived class calls it with `base(...)` when it is created.
- **Short Example:**

```csharp
public SavingsAccount(
	int accountNumber,
	string ownerName,
	decimal interestRate)
	: base(accountNumber, ownerName)
{
	InterestRate = interestRate;
}
```

### Abstract vs. Regular Methods

- **Term:** Abstract vs. Regular Methods
- **Definition:** An abstract method declares only required behavior and has no body. A regular method contains its implementation and can be inherited directly.
- **Short Example:**

```csharp
public abstract string GetAccountType();

public bool Deposit(decimal amount)
{
	// Regular method implementation
	return true;
}
```

### Abstract Class Without Abstract Methods

- **Term:** Abstract Class Without Abstract Methods
- **Definition:** An abstract class does not require abstract methods. It can be marked abstract simply to prevent direct instantiation while providing shared implemented behavior.
- **Short Example:**

```csharp
public abstract class BankAccount
{
	public bool Deposit(decimal amount)
	{
		return amount > 0;
	}
}
```

### Abstraction and Inheritance

- **Term:** Abstraction and Inheritance
- **Definition:** A derived class inherits shared behavior from the abstract base class and fulfills the abstract members it has been required to implement.
- **Short Example:**

```csharp
public class CheckingAccount : BankAccount
{
	public override string GetAccountType()
	{
		return "Checking Account";
	}
}
```

### Introduction to Runtime Polymorphism

- **Term:** Introduction to Runtime Polymorphism
- **Definition:** Different derived objects can execute their own implementations through a common `BankAccount` reference. The implementation used is determined by the actual object at runtime.
- **Short Example:**

```csharp
BankAccount savingsAccount = new SavingsAccount(1001, "Darryll", 0.03m);
BankAccount checkingAccount = new CheckingAccount(1002, "Darryll", 5000m);

Console.WriteLine(savingsAccount.GetAccountType());
Console.WriteLine(checkingAccount.GetAccountType());
```

## Quick Class Map

```text
BankAccount
├── AccountNumber, OwnerName, Balance
├── Deposit(), Withdraw(), GetAccountType()
├── SavingsAccount
│   └── InterestRate
└── CheckingAccount
	└── OverdraftLimit

BankService
└── manages List<BankAccount>

DisplayAccountInfo
└── formats and displays BankAccount data
```

## Phase Coverage

- **Phase 1 — Encapsulation:** Completed
- **Phase 2 — Inheritance:** Completed
- **Phase 3 — Abstraction:** Completed
- **Phase 4 — Polymorphism:** Next
- **Not covered as completed:** Interfaces
