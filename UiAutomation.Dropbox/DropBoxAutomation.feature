Feature: DropBoxAutomation
Develop an automated test for Dropbox and you need to login as a user add a folder, then upload 2-3 files to it.

Scenario: Upload and verifying files into dropbox
	Given I have logged in into drop box
	And I can see Home screen displayed with title 'Home'
	When I click on Files from the left hand panel 
	When I click on New folder 
	When I enter Folder name 'sample' and  select access as 'only you'	
	And I click on create
	Then I can see the folder is created
	When I click on upload files and  select the files 'Test.txt' to upload
	Then I can see the file 'Test.txt' is uploaded successfully
	And I logged out from dropbox

