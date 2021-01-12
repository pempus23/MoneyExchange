# MoneyExchange
Build an application which should be able to exchange money. App should have 2 screens,
exchange money and exchange history
.
1) Exchange money screen has to show 2 dropdowns and 2 inputs for FROM currency and TO
currency, USD, EUR, GBP, CHF should be supported.
User has to select FROM currency, TO currency, enter amount (both ways should be supported,
FROM-TO or TO-FROM). By clicking on the “exchange” button, the app has to call the
exchange rate API (https://api.exchangeratesapi.io/) to get a rate. Request to API has to be
made from back-end Note: page should not reload while getting exchange rate. Please add
messages in case of errors.
https://exchangeratesapi.io/ - exchange rate API docs and usage example
Example of exchange money screen
2) Exchange history page
For each call to exchange rate API app should save the data to database as:
Id
FromCurrency
FromAmount
ToCurrency
ToAmount
Date
So user should be able to see on this page all exchange history operations and also should be
able to search/filter for each column
