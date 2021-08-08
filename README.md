# Insurance Claims App

## Please add connection string in app settings for the database property (sensitive information shouldn't go out in the repo)

---

## Notes

1. Added some extra headers to the default setup for security purposes (nothing in place for api rate limitations)

2. Haven't done much testing, mainly setup a few integration tests(API folder) and some unit tests(Services folder); didn't use any mocking, simply using the in memory db to avoid repetitions

3. Used a custom implementation of an exception handler for production case scenario, and a custom page for http error status codes; this was done so as to illustrate ways of handling errors in a way that these can be logged or do other things with the data available in that context

4. Used EF scaffolding tool then removed irrelevant entities/fields
