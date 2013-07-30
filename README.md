# Windows Service Bootstrapper #

## What is it? ##
A helper library for constructing Windows Service with the help of TopShelf project.

## Installation ##
You can download the latest release from the **tag** section.

## Default configurations ##
By default, the service will be installed with the following settings:

 - Service depends on Event Log
 - Service starts automatically
 - Service runs as local service
 
If any of these doesn't suit you need, you can always either configure them through command line (topshelf feature), or create your own implementations of `IWindowsServiceBootstrapper`.

## License ##
__Windows Service Bootstrapper__ is release under MIT license as described in _License.txt_ file:

Copyright (c) 2013 Yin Zhang

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:
  
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.