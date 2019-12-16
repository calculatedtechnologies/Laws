//Create Asyncronous Tasks efficiently.
	
//Identify a function that returns a value
public double ExampleFunc(double a, double b)
{
	return a + b;
}

//Create a async function that returns a Task
private Task<double> asyncExampleFunc(double a, double b)
{
	return Task<double>.Run(() =>
	{
		return ExampleFunc(a, b);
	});
}


//Call the async function to await the asyncronous task	
public async void CallerFunc(double a, double b)
{
	//Await the identified function inside of the async function
	await (asyncExampleFunc(a,b));
}

//Test
//Write Unit Test that asserts that the async function returns a Task
		
//Snippet
