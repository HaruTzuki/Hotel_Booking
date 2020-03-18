# Hotel Booking
Small program written in C# with .NET Core 3 to Booking to a Hotel.

## What it offers
* You can book any of available hotels and you can put your departure date and arrival date and we cost autocally your booking.
* We send you confirmation email when a booking completed.
* You can watch your already bookings.

# How to Setup
You can download `master` branch and open `.sln` file. After this you can **build** the project as `Debug` or as `Release` and run it or in intergraded IIS from VS or in IIS from Windows.

## Setup your SMTP Credentials and Mail Form

### Setup your SMTP Credentials
In **Project Solution** you can find in `root` folder the file with name **appsettings.json** you can open it. In here you will see this:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Email": {
    "Smtp": {
      "Host": "SMTP_HOST",
      "Port": 587,
      "Ssl": false,
      "Username": "SMTP_USERNAME",
      "Password": "SMTP_PASSWORD"
    }
  }
}
```
You must change from `Email -> Smtp` values of **Host**, **Port**, **Ssl**, **Username**, **Password**:
* **Host**: Is from your e-mail provider IP or Domain.
* **Port**: Is from your e-mail provider Port. In which port E-Mail Server has setup it.
* **Ssl**: Is from your e-mail provider if use Secure or Insecure protocol.
* **Username**: Is your username to connect in this E-Mail Provider.
* **Password**: Is your password to connect in this E-Mail provider.

### Setup your mail form
We provide your the ability to change your e-mail form. E-Mail form accept and HTML tags but is in `.txt` file. This does not matters.
You can find this file in `Context\EmailBody.txt` and if you open it you see your email form. In this section we give you ability to put some variables with prefix `@`. Full list of variable we provide is below.

**Default E-Mail Form**
```html
<h2>Η κράτηση ολοκληρώθηκε με επιτυχία</h2>
<p>Ευχαριστούμε για την κράτηση Κύριε / Κυρία @LastName</p>
<p>Ο αριθμός της κράτησής σας είναι: @BookingId</p>

<h3>Το κατάλημα που έχετε κλείσει είναι το :</h3>

Περιγραφή: @HotelName<br>
Διεύθυνση: @HotelAddress<br>
Από ημ/νία: @BookingFromDate<br>
Έως ημ/νία: @BookingToDate<br>
Δωμάτια: @BookingRooms<br>
Τελικη Τιμή: @BookingCost €<br>
<br>
Βρισκόμαστε στην διάθεσή σας για οποιαδήποτε πληροφορία <a href="@Url">Hotel Booking</a>
```
### E-Mail Variables
* **@FirstName**: First Name of user.
* **@LastName**: Last Name of user.
* **@Address**: Address of user.
* **@Email**: E-Mail of user.
* **@Phone**: Phone number of user.
* **@BookingId**: Booking Unique Id.
* **@HotelName**: Name of hotel.
* **@HotelAddress**: Address of hotel.
* **@HotelDescription**: Description of hotel.
* **@HotelPrice**: Price per night of hotel.
* **@HotelAvailableRooms**: Available rooms of hotel.
* **@BookingFromDate**: Departure date of booking.
* **@BookingToDate**: Arrival date of booking.
* **@BookingRooms**: Ηow many rooms the user has booked.
* **@ΒookingCost**: How much booking cost.
* **@Url**: Basic url of application.
