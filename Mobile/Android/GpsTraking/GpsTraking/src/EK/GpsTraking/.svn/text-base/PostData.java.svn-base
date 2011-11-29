package EK.GpsTraking;

import java.io.ByteArrayOutputStream;
import java.io.IOException;

import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.StatusLine;
import org.apache.http.client.ClientProtocolException;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;


public abstract class PostData<T> extends AsyncTask<T, String, String>{
	
	protected Context uiContext;
	protected String locationServiceUrl;
	
	public PostData(Context uiContext, String locationServiceUrl)
	{
		this.uiContext = uiContext;
		this.locationServiceUrl = locationServiceUrl;
	}
	
	protected abstract HttpResponse postData(T data) throws ClientProtocolException, IOException;
	
    @Override
    protected String doInBackground(T... uri) {      
        HttpResponse response;
        String responseString = null;
        try {
        	Log.w("try to connect to", locationServiceUrl);
            response = postData(uri[0]);
            StatusLine statusLine = response.getStatusLine();
            if(statusLine.getStatusCode() == HttpStatus.SC_OK){
                ByteArrayOutputStream out = new ByteArrayOutputStream();
                response.getEntity().writeTo(out);
                out.close();
                responseString = out.toString();
                Log.d("all good", responseString);
            } else{
                //Closes the connection.
                response.getEntity().getContent().close();
                throw new IOException(statusLine.getReasonPhrase());
            }
        } catch (ClientProtocolException e) {
        	Log.w("url connect", e.toString());
            //TODO Handle problems..
        } catch (IOException e) {
        	Log.w("url connect", e.toString());
            //TODO Handle problems..
        }
        return responseString;
    }

    @Override
    protected void onPostExecute(String result) {
        super.onPostExecute(result);

        Toast.makeText(uiContext,
        		result, Toast.LENGTH_LONG).show();
        
        //((TextView) findViewById(R.id.TextReponse)).setText(result);
    }
}