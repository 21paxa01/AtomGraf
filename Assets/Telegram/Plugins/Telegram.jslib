var BrowserPlugin = {
    GetUserData: function()
    {
        var endpoint = JSON.stringify(window.Telegram.WebApp.initDataUnsafe.user);
        var bufferSize = lengthBytesUTF8(endpoint) + 1;
    	var buffer = _malloc(bufferSize);
    	stringToUTF8(endpoint , buffer, bufferSize);
    	return buffer;
     },
     GetInitData: function()
    {
        var endpoint = window.Telegram.WebApp.initData;
        var bufferSize = lengthBytesUTF8(endpoint) + 1;
    	var buffer = _malloc(bufferSize);
    	stringToUTF8(endpoint , buffer, bufferSize);
    	return buffer;
     },
     GetHash: function()
    {
        var endpoint = window.Telegram.WebApp.initDataUnsafe.hash;
        var bufferSize = lengthBytesUTF8(endpoint) + 1;
    	var buffer = _malloc(bufferSize);
    	stringToUTF8(endpoint , buffer, bufferSize);
    	return buffer;
     }
};

mergeInto(LibraryManager.library, BrowserPlugin);