Feature: CalcTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Add two numbers
	Given Calc '<calcType>' Is Opened
	When Input number '12'
	And Click button '+'
	And Input number '999'
	And Click button 'M+'
	And Input number '19'
	And Click button '+'
	And Click button 'MR'
	And Click button '='
	Then Result should be equal '1030'

	Examples:
	| calcType   |
	| Standard   |
	| Scientific |
