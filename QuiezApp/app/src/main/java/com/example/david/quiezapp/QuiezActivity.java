package com.example.david.quiezapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.AbstractList;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;

public class QuiezActivity extends AppCompatActivity {

    int i=0;
    ArrayList Quests;
    TextView txtQues;
  //  ResponsesClass x;
    String RaspunsA="[";
    String RaspunsF="[";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.quiez_layout);

        Quests = new ArrayList<>();
        Quests.add("Merele rosii sunt rosii");
        Quests.add("Pepenele e albastru");
        Quests.add("Mama ta e grasa");

        Button btnA = (Button)findViewById(R.id.btnA);
        Button btnF = (Button)findViewById(R.id.btnF);
        Button btnBack = (Button)findViewById(R.id.btnBack);
        Button btnNext = (Button)findViewById(R.id.btnNext);
        Button btnVerifica = (Button)findViewById(R.id.btnVerifica);
        txtQues = (TextView)findViewById(R.id.txtQues);

        txtQues.setText((String) Quests.get(i));

        btnNext.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                i++;
                if (i >= Quests.size()) {
                    i = 0;
                }
                txtQues.setText((String) Quests.get(i));
            }
        });
        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                i--;
                if (i < 0) {
                    i = Quests.size() - 1;
                }
                txtQues.setText((String) Quests.get(i));
            }
        });



        btnA.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RaspunsA+="{\"Id\":\"" + Integer.toString(i) + "\",\"Answere\":\"" + "A" + "\",\"Quest\":\"" + Quests.get(i) + "\"},";
                Verifica(i, "A");
            }
        });
        btnF.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RaspunsF+="{\"Id\":\"" + Integer.toString(i) + "\",\"Answere\":\"" + "F" + "\",\"Quest\":\"" + Quests.get(i) + "\"},";
                Verifica(i,"F");
            }
        });
        btnVerifica.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent myIntent = new Intent(QuiezActivity.this, ResoultsActivity.class);
                RaspunsA=RaspunsA.substring(RaspunsA.length()-1,1);
                RaspunsF=RaspunsF.substring(RaspunsF.length()-1,1);
                RaspunsA+="]";
                RaspunsF+="]";
                myIntent.putExtra("RAdevarat",RaspunsA);
                myIntent.putExtra("RFals",RaspunsF);
                QuiezActivity.this.startActivity(myIntent);
            }
        });
    }

    public void Verifica(int idQuez,String R)
    {
        switch (idQuez+"-"+R)
        {
             case "0-A":
                 Toast.makeText(QuiezActivity.this, "Ai Raspuns Corect", Toast.LENGTH_SHORT).show();
              break;
            case "0-F":
                Toast.makeText(QuiezActivity.this, "Ai Raspuns Gresit", Toast.LENGTH_SHORT).show();
                break;
            case "1-A":
                Toast.makeText(QuiezActivity.this, "Ai Raspuns Gresit", Toast.LENGTH_SHORT).show();
                break;
            case "1-F":
                Toast.makeText(QuiezActivity.this, "Ai Raspuns Corect", Toast.LENGTH_SHORT).show();
                break;
            case "2-A":
                Toast.makeText(QuiezActivity.this, "Ai Raspuns Corect", Toast.LENGTH_SHORT).show();
                break;
            case "2-F":
                Toast.makeText(QuiezActivity.this, "Ai Raspuns Gresit", Toast.LENGTH_SHORT).show();
                break;
         }
    }

}
