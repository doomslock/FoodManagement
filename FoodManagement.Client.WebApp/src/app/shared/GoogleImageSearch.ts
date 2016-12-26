/// <reference path="../../assets/libs/jsapi.ts" />

foodManagementApp.factory('GoogleImageSearch', function GoogleImageSearch() {
    return {
        Search: function (searchTerm: string) {
            let imageSearch;
            google.load('search', '1');

            imageSearch = new google.search.ImageSearch();

            // Set searchComplete as the callback function when a search is 
            // complete.  The imageSearch object will have results in it.
            let result = imageSearch.setSearchCompleteCallback(this, function () {
                if (imageSearch.results && imageSearch.results.length > 0) {

                    // Loop through our results, printing them to the page.
                    var results = imageSearch.results;
                    var result = results[0];
                    var imgContainer = document.createElement('div');
                    var title = document.createElement('div');

                    // We use titleNoFormatting so that no HTML tags are left in the 
                    // title
                    title.innerHTML = result.titleNoFormatting;
                    var newImg = document.createElement('img');

                    // There is also a result.url property which has the escaped version
                    newImg.src = "/image-search/v1/result.tbUrl;"
                    imgContainer.appendChild(title);
                    imgContainer.appendChild(newImg);

                    // Put our title + image in the content
                    return imgContainer;
                }
            }, null);

            // Find me a beautiful car.
            imageSearch.execute(searchTerm);

            // Include the required Google branding
            google.search.Search.getBranding('branding');

            return result;
        }
    }



    

});