Feature: BookRoomSection

@bookRoomSection
Scenario: Check the title of the rooms section
	Given Go to the home page of the hotel website
	When Check the title of the rooms section
	Then The section title is "Rooms"