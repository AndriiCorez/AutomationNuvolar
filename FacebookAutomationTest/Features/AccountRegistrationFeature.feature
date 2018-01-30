Feature: AccountRegistrationFeature
	As user 
	I want to be able to register new account
	So that I can use this account to login the system

@regression
Scenario: _Sign up successfully with correct required fields using email
	Given I open the main page
	And I have entered the following values to the registration form
	| Fname    | Sname       | Email               | Password   | Gender |
	| AutoName | AutoSurname | autoemail@gmail.com | AutoPass!1 | M      |
	When I click create account button
	Then I see a pop-up with 'Confirm Your Birthday' title

@regression
Scenario: _Sign up successfully with correct required fields using phone number
	Given I open the main page
	And I have entered the following values to the registration form without reentering email phone field
	| Fname    | Sname       | Email       | Password   | Gender |
	| AutoName | AutoSurname | 34987654321 | AutoPass!1 | M      |
	When I click create account button
	Then I see a pop-up with 'Confirm Your Birthday' title

@regression
Scenario: Sign up first name error correctness
	Given I open the main page	
	When I click create account button
	Then I see a "What’s your name?" first name error

@regression
Scenario: Sign up second name error correctness
	Given I open the main page	
	And I have entered the following values to the registration form
	| Fname      | Sname | Email            | Password   | Gender |
	| AutoName12 |       | asdasd@gmail.com | AutoPass!1 | M      |
	When I click create account button
	Then I see a "What’s your name?" second name error

@regression
Scenario: Sign up phone mail error correctness
	Given I open the main page
	And I have entered the following values to the registration form without reentering email phone field
	| Fname      | Sname         | Email | Password   | Gender |
	| AutoName12 | AutoSurname12 |       | AutoPass!1 | M      |
	When I click create account button
	Then I see a "You'll use this when you log in and if you ever need to reset your password." phone mail error

@regression
Scenario: Sign up password error correctness
	Given I open the main page	
	And I have entered the following values to the registration form
	| Fname      | Sname         | Email            | Password | Gender |
	| AutoName12 | AutoSurname12 | asdasd@gmail.com |          | M      |
	When I click create account button
	Then I see a "Enter a combination of at least six numbers, letters and punctuation marks (like ! and &)." password error

@regression
Scenario: Sign up gender error correctness
	Given I open the main page	
	And I have entered the following values to the registration form
	| Fname      | Sname         | Email            | Password   | Gender |
	| AutoName12 | AutoSurname12 | asdasd@gmail.com | AutoPass!1 |        |
	When I click create account button
	Then I see a "Please choose a gender. You can change who can see this later." gender error

@regression
Scenario Outline: Sign up password format error correctness
	Given I open the main page
	And I have entered default values in the fields and specific with '<password>' password 
	When I click create account button
	And I click Yes button on birthday confirmation window
	Then I see a "Please choose a more secure password. It should be longer than 6 characters, unique to you, and difficult for others to guess." general error
Examples: 
| password |
| aaaaaa   |
| 000000   |

@regression
Scenario Outline: Sign up password length error correctness
	Given I open the main page
	And I have entered default values in the fields and specific with '<password>' password 
	When I click create account button
	And I click Yes button on birthday confirmation window
	Then I see a "Your password must be at least 6 characters long. Please try another." general error
Examples: 
| password |
| 12345    |

@regression
Scenario Outline: Sign up email and phone format error correctness
	Given I open the main page
	And I have entered default values in the fields and specific with '<emailphone>' email or phone value 
	When I click create account button	
	Then I see a "Please enter a valid mobile number or email address." password error
Examples: 
| emailphone |
| abc        |
| abc@       |
| abc@de     |
| 341234567a |
| 123456789  |
| 34!2345689 |

@regression
Scenario Outline: Sign up name format error correctness for characters not allowed reason
	Given I open the main page
	And I have entered default values in the fields and specific with '<firstname>' first name and '<secondname>' second name values
	When I click create account button
	And I click Yes button on birthday confirmation window
	Then I see a "This name has certain characters that aren't allowed. Learn more about our name policies." general error
Examples: 
| firstname | secondname |
| abc       | 123        |
| 123       | xyz        |

@regression
Scenario Outline: Sign up name format error correctness for email reason
	Given I open the main page
	And I have entered default values in the fields and specific with '<firstname>' first name and '<secondname>' second name values
	When I click create account button
	And I click Yes button on birthday confirmation window
	Then I see a "It looks like you entered a mobile number or email. Please enter your name." general error
Examples: 
| firstname | secondname |
| !@_       | xyz        |
| abc       | !@_        |

@regression
Scenario Outline: Sign up name celebrity error correctness
	Given I open the main page
	And I have entered default values in the fields and specific with '<firstname>' first name and '<secondname>' second name values
	When I click create account button
	And I click Yes button on birthday confirmation window
	Then I see a "It seems like you're trying to create a profile for a celebrity. Learn more about our name policies, including how to let us know if this is the name you use in everyday life, what your friends call you." general error
Examples: 
| firstname | secondname |
| John      | Cena       |
| Barak     | Obama      |
