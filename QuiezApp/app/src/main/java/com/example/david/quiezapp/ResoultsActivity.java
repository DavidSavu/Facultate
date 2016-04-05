package com.example.david.quiezapp;

import android.content.Intent;
import android.renderscript.Element;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class ResoultsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.resoults_layout);

        TextView txtRespons =(TextView)findViewById(R.id.txtRespons);
        Intent myIntent=getIntent();

 //       txtRespons.setText(Integer.toString(x.Count()));
        String A = "";
        String F = "";


        A = myIntent.getStringExtra("RAdevarat");
        F = myIntent.getStringExtra("RFals");

        String raspuns1 = "";
        String raspunsF = "";


        if (A.length() < 4)
        {
            raspuns1 = "Nu ai raspuns cu A la nici o intrebare";
        } else
        {
            try {
                JSONArray JAA = new JSONArray(A);
                for (int i=0 ;i < JAA.length();i++) {
                    JSONObject JA = JAA.getJSONObject(i);
                    raspuns1 += "Raspunsul tau la intrebarea numarul :" + JA.getJSONObject("Id") + JA.getJSONObject("Quest") + "a fost :" + JA.getJSONObject("Answere");
                }
            }catch (JSONException ex) {
                Log.e("MYAPP", "unexpected JSON exception", ex);}
        }


        if (F.length() < 4)
        {
            raspunsF = "Nu ai raspuns cu F la nici o intrebare";
        }else
        {
            try
            {
                JSONArray JFA = new JSONArray(F);
                for (int i=0 ;i < JFA.length();i++) {
                    JSONObject JF = JFA.getJSONObject(i);
                    raspunsF += "Raspunsul tau la intrebarea numarul :" + JF.getJSONObject("Id") + ". " + JF.getJSONObject("Quest") + "a fost :" + JF.getJSONObject("Answere");
                }
            }catch (JSONException ex) {
                Log.e("MYAPP", "unexpected JSON exception", ex);}
        }

        txtRespons.setText(raspuns1 + " iar raspunsurile cu F au fost " + raspunsF);

    }
}
