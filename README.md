Vecc.WebSecurity
================

Easy implementation of a bunch of anti cross site scripting headers for asp.net

Simply add a reference to the library, a few lines to global.asax.cs and thats about it. The example site in here shows it all along with a little, albeit quirky, playground to test and see what the different settings will do.

I will leave it up to you to figure out what browsers supports what. But, Internet Explorer doesn't seem to do anything with content-security-policy header or the x-strict-transport-security header. Chrome works with them all though.

As I learn more about easy to implement security things, I'll be updating this library.
