package EK.GpsTraking;

import java.io.IOException;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;

import android.content.Context;


public class PostGpsSession extends PostData<GpsSession>
{
	public PostGpsSession(Context uiContext, String locationServiceUrl)
	{
		super(uiContext, locationServiceUrl);
	}

	@Override
	protected HttpResponse postData(GpsSession data) throws ClientProtocolException, IOException {
		 HttpClient httpclient = new DefaultHttpClient();
		 
		 System.out.println("Call url: " + locationServiceUrl);		
		 return httpclient.execute(new HttpPost(locationServiceUrl));
		 //return httpclient.execute(new HttpPost(String.format("{0}/{1}/{2}/{3}", locationServiceUrl, data.Latitude, data.Longitude)));
	}
}