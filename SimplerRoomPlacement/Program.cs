using System.Diagnostics.Tracing;

Console.WriteLine("Hello, World!");

int xAxis = 200;
int yAxis = 200;
int numberOfRooms = 10;
int counter = 0;

string filePath = @"C:\Users\limbo\Documents\SOFTWARE - UNI\P4\SimpleRoomPlacement";

string[,] lines = new string[yAxis, xAxis];
for(int i = 0; i < yAxis; i++){
    for(int j = 0; j < xAxis; j++){
        lines[i,j] = " ";
    }
}

while(counter <= numberOfRooms){

    
    Random rand = new Random();

    //"-5" is a minimum constraint so that rooms arent too small
    int topLeftCornerXcoordinate = rand.Next(0, xAxis-5);
    int topLeftCornerYcoordinate = rand.Next(0, yAxis-5);
    Console.WriteLine("{0} and {1}", topLeftCornerXcoordinate, topLeftCornerYcoordinate);

    //"+5" is a minimum constraint so that rooms arent too small
    int bottomRightCornerXcoordinate = rand.Next(topLeftCornerXcoordinate+5, xAxis);
    int bottomRightCornerYcoordinate = rand.Next(topLeftCornerYcoordinate+5, yAxis);
    Console.WriteLine("x = {0} and y = {1}", bottomRightCornerXcoordinate, bottomRightCornerYcoordinate);

    //Check if any room is inside new room
    bool roomAlreadyThere = false;
    for(int i = topLeftCornerYcoordinate; i < bottomRightCornerYcoordinate; i++){
        for(int j = topLeftCornerXcoordinate; j < bottomRightCornerXcoordinate; j++){
            if(lines[i,j] == "R" || lines[i,j] == "F"){
                roomAlreadyThere = true;
                break;
            }
        }
    }

    if(roomAlreadyThere == false){
        //Write lines to array
        //Write room sides
        for(int i = topLeftCornerXcoordinate; i <= bottomRightCornerXcoordinate; i++){
            lines[topLeftCornerYcoordinate, i] = "R";
            lines[bottomRightCornerYcoordinate, i] = "R";
        }

        for(int i = topLeftCornerYcoordinate; i<= bottomRightCornerYcoordinate; i++){
            lines[i, topLeftCornerXcoordinate] = "R";
            lines[i, bottomRightCornerXcoordinate] = "R";
        }

        for(int i = topLeftCornerYcoordinate+1; i < bottomRightCornerYcoordinate; i++){
            for(int j = topLeftCornerXcoordinate+1; j < bottomRightCornerXcoordinate; j++){
                lines[i,j] = "F";
            }
        }
        
        counter++;
    }
}


using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "map.txt")))
    {
        

        int rowLength = lines.GetLength(0);
        int colLength = lines.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                outputFile.Write(string.Format("{0}", lines[i,j]));
            }
            outputFile.Write(Environment.NewLine);
        }
    } 
/*



// Create a string array with the lines of text
        string[] lines = { "First line", "Second line", "Third line" };

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }

*/