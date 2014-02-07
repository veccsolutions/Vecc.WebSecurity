Vecc.WebSecurity
================

Easy implementation of a bunch of anti cross site scripting headers for asp.net

Simply add a reference to the library, a few lines to global.asax.cs and thats about it. The example site in here shows it all along with a little, albeit quirky, playground to test and see what the different settings will do.

I will leave it up to you to figure out what browsers supports what as that changes frequently. But, Internet Explorer doesn't seem to do anything with content-security-policy header or the x-strict-transport-security header. Chrome works with them all though.

As I learn more about not-out-of-the-box security controls like the following, I will update this library to make them easy to implement.

Curent Features
----------------
###Library
* Each "policy" is easily enabled and disabled. They all have a bool option, Enabled.
* There is a main Security class, that contains all of the "policies". Makes it so you only call one method to apply them all. 
* Absolutely no dependencies on 3rd party libraries.
* MIT License, security should be easy for everyone.

###x-strict-transport-security
Current browser support: <http://caniuse.com/#feat=stricttransportsecurity>
* Allows auto redirect to https if on http
* Adds header only if https
* Customizable way of determining http/https (usually for ssl offloaders/load balancers)
* Customizable way of determining absolute url (usually for ssl offloaders/load balancers)
* Defaults to using the easy .net way of determining the http/https/absolute urls.
* Easy to access maxcache for length of browser to cache

###content-security-policy
Current browser support: <http://caniuse.com/#feat=contentsecuritypolicy>
* Includes current 1.0 spec's directives
* Can add custom directives (though they will probably never get used)
* Prebuilt sources, 'self', https:, 'none', 'inline-eval' etc.
* Predefined, quickly usable defaults. Currently Https only, None and Self.
* Easy to add custom urls with the Domains property (it's an ICollection<string>)
* Report only mode
* Violation report framework is there (simple interface and class)
* Example site has an implementation of an HttpHandler that will write the violation to the debugger.
* Logger implementation is really easy, single method, can go to wherever you want.

###x-xss-protection
Current browser support: <x-xss-protection browser support> (As of the time of this writing, IE, Chrome and Safari supported it, Firefox was not.)
* Allows predefined and valid values, Disabled, Enabled, Enabled and block

