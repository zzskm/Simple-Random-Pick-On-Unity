using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginVertical();

        GUILayout.Label(new string('-', 24));

        if(GUILayout.Button("Test"))
        {
            Test();
        }

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    private void Test()
    {
        int count = Random.Range(15, 35);

        int[] probabilities = new int[count];

        for (int i = 0; i < probabilities.Length; ++i)
        {
            probabilities[i] = Random.Range(10, 200);
        }

        {
            string output = "probabilities\n";

            int total = 0;

            for (int i = 0; i < probabilities.Length; ++i)
            {
                total += probabilities[i];
            }

            for (int i = 0; i < probabilities.Length; ++i)
            {
                output += i + " : " + probabilities[i] + " " + (probabilities[i] / (float)total).ToString("#0.00 %") + "\n";
            }

            Debug.Log(output);
        }

        int[] results = new int[count];

        for (int n = 0; n < 50000; ++n)
        {
            int p = Pick(probabilities);
            ++results[p];
        }

        {
            string output = "results\n";

            int total = 0;

            for (int i = 0; i < results.Length; ++i)
            {
                total += results[i];
            }

            for (int i = 0; i < results.Length; ++i)
            {
                output += i + " : " + results[i] + " " + (results[i] / (float)total).ToString("#0.00 %") + "\n";
            }

            Debug.Log(output);
        }
    }

    private int Pick(int[] probabilities)
    {
        int total = 0;

        for (int i = 0; i < probabilities.Length; ++i)
        {
            total += probabilities[i];
        }

        int n = Random.Range(0, total);

        for (int i = probabilities.Length - 1; i > -1; --i)
        {
            total -= probabilities[i];

            if (total <= n)
            {
                return i;
            }
        }

        return -1;
    }
}
