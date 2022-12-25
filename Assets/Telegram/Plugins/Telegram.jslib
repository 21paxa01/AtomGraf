var BrowserPlugin = {
    GetUserData: function()
    {
        var endpoint = JSON.stringify(window.Telegram.WebApp.WebAppUser);
        var bufferSize = lengthBytesUTF8(endpoint) + 1;
    	var buffer = _malloc(bufferSize);
    	stringToUTF8(endpoint , buffer, bufferSize);
    	return buffer;
     }
};

mergeInto(LibraryManager.library, BrowserPlugin);