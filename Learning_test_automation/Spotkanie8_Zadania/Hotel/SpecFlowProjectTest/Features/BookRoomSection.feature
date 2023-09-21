Feature: BookRoomSection

@bookRoomSection
Scenario: Check the title of the room book section
	Given Go to the home page of the hotel website
	When Check the title of the rooms section
	Then The section title is "Rooms"

@bookRoomSection
Scenario: Check the headline of the room book article
	Given Go to the home page of the hotel website
	When Check the title of the headline rooms article
	Then The headline rooms article is "single"

@bookRoomSection
Scenario: Check the number of points in the room book article
	Given Go to the home page of the hotel website
	When Check the amount of points in the room article
	Then The room article have 3 points

@bookRoomSection
Scenario: Check if a photo of the room book section appears
	Given Go to the home page of the hotel website
	When Check if a photo of the room section appears
	Then A photo of the room will appear in the room section

@bookRoomSection
Scenario: Check if there is a wheelchair icon in the room book section
	Given Go to the home page of the hotel website
	When Check if there is a wheelchair icon in the room section
	Then A icon of the wheelchair will appear in the room section

@bookRoomSection
Scenario: Check if appear right content in the room book article
	Given Go to the home page of the hotel website
	When Check if appear right content in the room book article
	Then A content of the room book article is right
	
@bookRoomSection
Scenario: Check if room booking button has correct text in the room book section
	Given Go to the home page of the hotel website
	When Check if room booking button has correct text in the room book section
	Then A text from room booking button has correct
	
@bookRoomSection
Scenario: Check if room booking button appear
	Given Go to the home page of the hotel website
	When Check if room booking button appear
	Then A room booking button appear
	
@bookRoomSection
Scenario: Check if alert book notification appear when book date without enter any date
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Click book date button
	Then Appear alert book notification with 9 alerts
	
@bookRoomSection
Scenario: Check if calendar disappear from the room book section when click cancel button on book date window
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Click book date cancel button
	Then Calendar disappear
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the name field to short name
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "name" field with data "St"
	And Click book date button
	Then Appear alert book notification with 8 alerts

@bookRoomSection
Scenario: Check if alert book notification appear when fills in the name field correctly
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "name" field with data "Stefek"
	And Click book date button
	Then Appear alert book notification with 7 alerts

@bookRoomSection
Scenario: Check if alert book notification appear when fills in the lastname field to short name
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "lastname" field with data "Pi"
	And Click book date button
	Then Appear alert book notification with 8 alerts
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the lastname field correctly
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "lastname" field with data "PierdziBący"
	And Click book date button
	Then Appear alert book notification with 7 alerts
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the email field incorrectly
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "email" field with data "hWDPna50%BoTrocheSieBoje"
	And Click book date button
	Then Appear alert book notification with 9 alerts
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the email field correctly
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "email" field with data "spokoAdres@giewno.com"
	And Click book date button
	Then Appear alert book notification with 9 alerts
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the phone number field to short number
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "phone" field with data "070088891"
	And Click book date button
	Then Appear alert book notification with 8 alerts
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the phone number field to long number
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "phone" field with data "070088891070088891070088891"
	And Click book date button
	Then Appear alert book notification with 8 alerts
	
@bookRoomSection
Scenario: Check if alert book notification appear when fills in the phone number field correctly
	Given Go to the home page of the hotel website
	When Click book this room button from room section
	And Calendar should appear
	And Fill in the "phone" field with data "07008889101"
	And Click book date button
	Then Appear alert book notification with 8 alerts