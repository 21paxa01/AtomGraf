var BrowserPlugin = {
    FixAudio__proxy: 'sync',
FixAudio__sig: 'v',
FixAudio: function ()
{
  window.addEventListener('mousedown', function()
  {
  if (WEBAudio.audioWebEnabled == 0)
    return;
  if (WEBAudio.audioContext.state === 'suspended')
    WEBAudio.audioContext.resume();
  });
  window.addEventListener('touchstart', function()
  {
  if (WEBAudio.audioWebEnabled == 0)
    return;
  if (WEBAudio.audioContext.state === 'suspended')
    WEBAudio.audioContext.resume();
  });
},
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
     },
	OpenURI: function(url)
     {
        url = Pointer_stringify(url);
        window.open(url,'_blank');
     }
};

mergeInto(LibraryManager.library, BrowserPlugin);