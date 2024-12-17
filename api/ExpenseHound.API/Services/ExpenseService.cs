using ExpenseHound.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ExpenseHound.API.Services
{
    /// <summary>
    /// Expense service class that interacts with the MongoDB database
    /// </summary>
    public class ExpenseService
    {
        /// <summary>
        /// MongoDB collection of expenses
        /// </summary>
        private readonly IMongoCollection<Expense> _expenses;


        /// <summary>
        /// Constructor for the ExpenseService class, which initializes the MongoDB collection
        /// </summary>
        /// <param name="config"></param>
        public ExpenseService(IConfiguration config)
        {
            var connectionString = Environment.GetEnvironmentVariable("MongoDB__ConnectionString");
            var dbName = Environment.GetEnvironmentVariable("MongoDB__DatabaseName");
            var expCollection = Environment.GetEnvironmentVariable("MongoDB__CollectionNameExp");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _expenses = database.GetCollection<Expense>(expCollection);
        }


        // Get all expenses
        /// <summary>
        /// Get all expenses from the MongoDB collection
        /// </summary>
        /// <returns>All expenses</returns>
        public List<Expense> Get() => _expenses.Find(expense => true).ToList();


        // Get expenses by ID
        /// <summary>
        /// Get an expense by its ID
        /// </summary>
        /// <param name="id">ObjectID from MongoDB</param>
        /// <returns>An individual Expense</returns>
        public Expense Get(string id) => _expenses.Find<Expense>(expense => expense.Id == id).FirstOrDefault();


        //Add a new expense
        /// <summary>
        /// Creates a new expense in the MongoDB collection
        /// </summary>
        /// <param name="expense">Creates a new Expense object</param>
        /// <returns>The newly created expense</returns>
        public Expense Create(Expense expense)
        {
            _expenses.InsertOne(expense);
            return expense;
        }


        // Update an expense
        /// <summary>
        /// Updates an existing expense in the MongoDB collection
        /// </summary>
        /// <param name="id">MongoDB ObjectID</param>
        /// <param name="expenseIn">Expense to be updated</param>
        public void Update(string id, Expense expenseIn) => _expenses.ReplaceOne(expense => expense.Id == id, expenseIn);


        // Delete an expense
        /// <summary>
        /// Deletes an expense from the MongoDB collection
        /// </summary>
        /// <param name="expenseIn">Expense to be deleted</param>
        public void Remove(Expense expenseIn) => _expenses.DeleteOne(expense => expense.Id == expenseIn.Id);
    }
}
