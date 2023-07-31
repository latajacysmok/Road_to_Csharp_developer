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