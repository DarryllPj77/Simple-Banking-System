# Simple Banking System — OOP C# Learning Roadmap

This roadmap tracks the OOP concepts practiced while building the Simple Banking System with .NET 10.

## Progress Legend

- ✅ Completed
- 🟡 Current
- ⬜ Planned

---

## Phase 1 — Encapsulation ✅ Completed

### Goals

- Protect the internal state of `BankAccount`.
- Control how other parts of the program modify account data.
- Separate banking logic from presentation logic.

### Completed Tasks

#### 1. Create `BankAccount`

Created the core model with encapsulated properties:

```csharp
public int AccountNumber { get; private set; }
public string OwnerName { get; private set; }
public decimal Balance { get; private set; }
```

`get; private set;` means other classes can read the property, but only the `BankAccount` class can directly modify it.

#### 2. Create `Deposit()`

```csharp
public bool Deposit(decimal amount)
```

The method:

- Rejects zero or negative deposits.
- Modifies `Balance` through controlled behavior.
- Returns whether the operation succeeded.

Instead of directly changing the balance:

```csharp
// Not allowed outside BankAccount
account.Balance = 1000m;
```

The account is modified through its behavior:

```csharp
account.Deposit(1000m);
```

#### 3. Create `Withdraw()`

```csharp
public bool Withdraw(decimal amount)
```

The method:

- Rejects zero and negative amounts.
- Prevents withdrawing more than the available balance.
- Prevents the balance from becoming negative.

#### 4. Apply Separation of Concerns

Account formatting was moved from `BankAccount` into:

```text
UI/
└── DisplayAccountInfo.cs
```

- `BankAccount` handles banking data and behavior.
- `DisplayAccountInfo` handles presentation and formatting.

#### 5. Create `BankService`

Created a private account collection:

```csharp
private readonly List<BankAccount> _accounts = new();
```

Added controlled operations:

- `AddAccount(...)`
- `GetAccountByNumber(...)`

The account list is private, so other classes cannot directly replace or manipulate the internal collection.

### Phase 1 Summary

```text
BankAccount
├── AccountNumber
│   ├── public get
│   └── private set
├── OwnerName
│   ├── public get
│   └── private set
├── Balance
│   ├── public get
│   └── private set
├── Deposit()
│   └── controlled modification
└── Withdraw()
	└── controlled modification

BankService
└── private List<BankAccount>
	├── AddAccount()
	└── GetAccountByNumber()
```

### Key Lesson

> Encapsulation means protecting an object's internal data and providing controlled ways to interact with or modify that data.

---

## Phase 2 — Inheritance ✅ Completed

### Main Goal

Reuse common account behavior while allowing specialized account types to add their own rules and features.

### Phase 2 Task Plan

#### Task 6 — Create `SavingsAccount` ✅ Completed

Derive `SavingsAccount` from `BankAccount`:

```csharp
public class SavingsAccount : BankAccount
{
	public decimal InterestRate { get; private set; }

	public SavingsAccount(
		int accountNumber,
		string ownerName,
		decimal interestRate)
		: base(accountNumber, ownerName)
	{
		InterestRate = interestRate;
	}
}
```

#### Task 7 — Test Inherited Members ✅ Completed

**File:** `Program.cs`

Prove that `SavingsAccount` inherits from `BankAccount`:

- Create a `SavingsAccount`.
- Call inherited `Deposit()`.
- Call inherited `Withdraw()`.
- Access inherited `AccountNumber`, `OwnerName`, and `Balance`.
- Access the savings-specific `InterestRate`.
- Display the account using `DisplayAccountInfo`.

Example:

```csharp
SavingsAccount savingsAccount = new(
	123456789,
	"Darryll Pajaganas",
	0.05m);

savingsAccount.Deposit(1000m);
savingsAccount.Withdraw(250m);

Console.WriteLine($"Account Number: {savingsAccount.AccountNumber}");
Console.WriteLine($"Owner: {savingsAccount.OwnerName}");
Console.WriteLine($"Balance: {savingsAccount.Balance:F2}");
Console.WriteLine($"Interest Rate: {savingsAccount.InterestRate:P}");
Console.WriteLine(DisplayAccountInfo.GetAccountInfo(savingsAccount));
```

#### Task 8 — Create `CheckingAccount` ✅ Completed

Create another child class that inherits from `BankAccount`:

```text
			 BankAccount
			  /        \
			 /          \
SavingsAccount      CheckingAccount
```

Give `CheckingAccount` a feature that distinguishes it from `SavingsAccount`.

#### Task 9 — Work with Child Objects as `BankAccount` ✅ Completed

Practice this relationship:

```csharp
BankAccount account = new SavingsAccount(
	123456789,
	"Darryll Pajaganas",
	0.05m);
```

This demonstrates that a `SavingsAccount` is a `BankAccount` and prepares the project for polymorphism.

#### Task 10 — Store Different Account Types Together ✅ Completed

Confirm that the existing `List<BankAccount>` can contain both `SavingsAccount` and `CheckingAccount` objects:

```text
_accounts
├── SavingsAccount
├── CheckingAccount
├── SavingsAccount
└── CheckingAccount
```

#### Task 11 — Review Inheritance Access Modifiers ✅ Completed

Review how `public`, `private`, and `protected` members behave with inheritance. Use `protected` only when there is a legitimate design reason.

#### Task 12 — Review Inheritance Design ✅ Completed

Explain these relationships:

- `SavingsAccount` **IS-A** `BankAccount`.
- `CheckingAccount` **IS-A** `BankAccount`.
- `BankService` **HAS/MANAGES** `BankAccount` objects.
- `DisplayAccountInfo` **USES** a `BankAccount`.

Inheritance should represent a meaningful **IS-A** relationship, not only provide a way to avoid copying code.

### Inheritance Examples

#### Understand the `base` Constructor

The derived class must call the base constructor so that the inherited `AccountNumber` and `OwnerName` properties are initialized.

```csharp
: base(accountNumber, ownerName)
```

#### Add Savings Account Behavior

Possible behavior to implement:

- Calculate interest.
- Apply interest to the balance.
- Validate the interest rate.

Example future method:

```csharp
public bool ApplyInterest()
```

#### Store Derived Accounts in `BankService`

Confirm that a `SavingsAccount` can be stored in a `List<BankAccount>` because a savings account is also a bank account.

```csharp
BankAccount account = new SavingsAccount(
	123456789,
	"Darryll Pajaganas",
	0.05m);
```

#### Test Inherited Behavior

Verify that `SavingsAccount` can use inherited members:

```csharp
account.Deposit(1000m);
account.Withdraw(250m);
```

### Phase 2 Checklist

- [x] Create `SavingsAccount : BankAccount`.
- [x] Add the `InterestRate` property.
- [x] Call the `BankAccount` constructor with `base(...)`.
- [x] Test inherited `Deposit()` and `Withdraw()` behavior in `Program.cs`.
- [x] Create `CheckingAccount : BankAccount`.
- [x] Practice parent-type references to child objects.
- [x] Store savings and checking accounts in one collection.
- [x] Review `public`, `private`, and `protected` inheritance access.
- [x] Complete the inheritance relationship/design review.

---

## Phase 3 — Abstraction ✅ Completed

### Main Goal

Expose essential account behavior while hiding implementation details behind an abstract base class.

### Completed Tasks

#### Task 13 — Abstract Class ✅

Converted `BankAccount` into an abstract class and verified that it cannot be instantiated directly.

#### Task 14 — Abstract Method ✅

Declared `GetAccountType()` as an abstract method in `BankAccount` and observed the compiler requirement for concrete derived classes to implement it.

#### Task 15 — Method Implementation ✅

Implemented `GetAccountType()` with `override` in `SavingsAccount` and `CheckingAccount`.

#### Task 16 — Abstract Method Testing ✅

Tested `GetAccountType()` through `BankAccount` references pointing to different child objects.

#### Task 17 — Knowledge Review ✅

Reviewed abstract classes, abstract methods, overriding, and their relationships.

### Phase 3 Checklist

- [x] Convert `BankAccount` to an abstract class.
- [x] Declare `GetAccountType()` as an abstract method.
- [x] Implement `GetAccountType()` in `SavingsAccount`.
- [x] Implement `GetAccountType()` in `CheckingAccount`.
- [x] Test the method through `BankAccount` references.
- [x] Review abstraction and its relationship with inheritance.

---

## Phase 4 — Polymorphism ⬜ Planned

### Main Goal

Allow different account objects to respond to the same operation through a common `BankAccount` reference.

### Planned Topics

- Runtime method dispatch.
- `virtual` methods.
- `override` methods in polymorphic designs.
- Different account-specific behavior through a shared base type.
- When polymorphism is useful in the banking system.

---

## Phase 5 — Service and Application Improvements ⬜ Planned

### Main Goal

Improve the structure and usability of the application after the core OOP principles are implemented.

### Planned Topics

- Better validation and error messages.
- Account transfer functionality.
- Transaction history.
- More service methods.
- Console menu design.
- Dependency injection basics.
- Unit testing.
- File or database persistence.

---

## Learning Principles

1. Keep data protected.
2. Let objects control their own behavior.
3. Keep each class focused on one responsibility.
4. Reuse common behavior through inheritance only when the relationship is appropriate.
5. Prefer clear, maintainable code over clever code.
6. Add tests as new behavior is introduced.

## Current Status

- **Phase 1 — Encapsulation:** ✅ Completed
- **Phase 2 — Inheritance:** ✅ Completed
- **Phase 3 — Abstraction:** ✅ Completed
- **Phase 4 — Polymorphism:** ⬜ Planned
- **Phase 5 — Service and Application Improvements:** ⬜ Planned
