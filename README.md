# PE02 - Coffee Farmers
## Account login credentials

### User accounts:
- Username: bob | Password: password
- Username: joemama | Password: password

### Admin accounts:
- Username: bsoete | Password: password
- Username: jders | Password: password

## Shopping Cart
The application allows signed in users to add to cart and proceed to checkout.

## Order Manager and email recipient
Admin accounts will be able to confirm unshipped orders via the Order Manager option in the Admin Portal.
Note that this will trigger an email to be sent to the email address currently hard coded in: **Area: Admin > Controller: Order > Action: Confirm**. To test this feature, please change the string variable "recipientEmail" on **line 49** to the desired email address.

Also note that after testing, the Outlook "from" authentication seems to time out after approximately 24 hours. Any issues will be intercepted in the catch block so the application will not be affected. For testing purposes, you could also update the credential variables in **Services** > **EmailSenderService** on **lines 12 & 13**.
