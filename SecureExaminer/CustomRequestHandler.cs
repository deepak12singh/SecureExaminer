﻿using CefSharp;
using System.Security.Cryptography.X509Certificates;

public class CustomRequestHandler : IRequestHandler
{
    public CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
    {
        var headers = request.Headers;
        headers["Authorization"] = "Bearer YOUR_TOKEN_HERE";  // Ensure this is the actual token
        headers["X-SecureExaminer"] = "ActiveExam";  // Ensure this header is being added correctly

        request.Headers = headers;  // Reassign the headers with your custom ones

        return CefReturnValue.Continue;  // Continue with the request
    }


    public bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
    {
        return false;
    }

    public bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
    {
        return false;
    }

    public void OnPluginCrashed(IWebBrowser chromiumWebBrowser, IBrowser browser, string pluginPath)
    {
    }

    public bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
    {
        return false;
    }

    public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
    {
        return false;
    }

    public void OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
    {
    }

    public void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status, int exitCode, string message)
    {
    }

    public bool GetAuthCredentials(
        IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl,
        bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
    {
        return false;
    }

    public bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
    {
        return false;
    }

    public void OnDocumentAvailableInMainFrame(IWebBrowser chromiumWebBrowser, IBrowser browser)
    {
    }

    public void OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
    {
    }

    public bool OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, string url)
    {
        return false;
    }

    public IResourceRequestHandler GetResourceRequestHandler(
        IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request,
        bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
    {
        return null;
    }
}
