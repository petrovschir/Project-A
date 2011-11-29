package EK.GpsTraking;

import android.app.Activity;
import android.content.Context;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class GpsTrakingActivity extends Activity implements LocationListener {
	private TextView latituteField;
	private TextView longitudeField;
	private LocationManager locationManager;
	private String provider;
	
	private double latitude;
	private double longitude;
	
	private String locationServiceUrl = "http://www.google.com";
	//http://10.0.2.2/GPSLocationService/help/operations/RegisterUser/%7Bmyname%7D/%7Bmyaddress%7D
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
		latituteField = (TextView) findViewById(R.id.TextView02);
		longitudeField = (TextView) findViewById(R.id.TextView04);

		// Get the location manager
		locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		// Define the criteria how to select the location provider -> use default
		
		Criteria criteria = new Criteria();
		provider = locationManager.getBestProvider(criteria, false);
		Location location = locationManager.getLastKnownLocation(provider);

		// Initialize the location fields
		if (location != null) {
			System.out.println("Provider " + provider + " has been selected.");			
			updateLocation(location);
		} else {
			latituteField.setText("Provider not available");
			longitudeField.setText("Provider not available");
		}
	}

	private void updateLocation(Location location) {
		latitude = location.getLatitude();
		longitude = location.getLongitude();
		latituteField.setText(String.valueOf(latitude));
		longitudeField.setText(String.valueOf(longitude));
	}

	public void ButtonPostCoordCLick(View view)
	{
		PostGpsLocation postData = new PostGpsLocation(this, locationServiceUrl);
		GpsLocation location = new GpsLocation();
		location.Latitude = latitude;
		location.Longitude = longitude;
		location.Note = ((EditText) findViewById(R.id.EditViewComment)).getText().toString();
		postData.execute(location);	
	}
	
	/* Request updates at startup */
	@Override
	protected void onResume() {
		super.onResume();
		locationManager.requestLocationUpdates(provider, 400, 1, this);
	}

	/* Remove the location listener updates when Activity is paused */
	@Override
	protected void onPause() {
		super.onPause();
		locationManager.removeUpdates(this);
	}

	public void onLocationChanged(Location location) {
		updateLocation(location);
	}

	public void onStatusChanged(String provider, int status, Bundle extras) {
		// TODO Auto-generated method stub

	}

	public void onProviderEnabled(String provider) {
		Toast.makeText(this, "Enabled new provider " + provider,
				Toast.LENGTH_SHORT).show();

	}

	public void onProviderDisabled(String provider) {
		Toast.makeText(this, "Disenabled provider " + provider,
				Toast.LENGTH_SHORT).show();
	}	
}