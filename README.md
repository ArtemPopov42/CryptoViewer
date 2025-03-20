Notes:

	For all data except charts, the application uses CoinCap API v3 instead of v2  proposed in the test assignment, because according to CoinCap documentation, the second version will be clossed on March 31 2025.
	Due to limitations on the free plan of the CoinCap API, the number of loaded currencies is limited to 10, and the number of loaded markets for each currency is limited to 20. Additionally, update rate for both lists is set to 30 seconds.
	For loading chart data, the Binance API is used because CoinCap API does not have suitable endpoints, but Binance API provides data only for exchanges between cryptocurrencies, which means the application cannot provide data for exchanges like Bitcoin to US dollars.

Main View:

	- The main view displays a list of cryptocurrencies returned by the CoinCap API.
	- The list of currencies updates automatically when the view is active.
	- At the top of the currency list, there is a search text box for filtering cryptocurrencies by name or symbol (entries are filtered after each text update).
	- Clicking on a list entry opens a new view with detailed information about the selected cryptocurrency, and a tab for this view is added to the top navigation panel.
	- Navigation between opened currency detail views is managed through a stack of tabs at the top of the application, along with a static button that returns to the currency list view.

Currency Details View:

	- This view contains detailed information about a currency, including its name, symbol, price in USD, market cap in USD, price change, volume, VWAP, supply, and max supply.
	- It includes a list of markets where this currency is traded.
	- The market list updates automatically when the view is active.
	- Clicking on a market entry displays a candlestick chart with data from the Binance API.
	- Above the chart, there are buttons for changing the candlestick interval (1, 5, 15 minutes, 1 hour, 1 day).
	- The chart updates automatically when the view is active, following the selected interval (default interval: 1 minute).