namespace Tarefas.ListaTarefas
{
    class ListaTarefas
    {
    
        public Guid Id {get; set;}
        public string tarefa {get; set;}
        public bool concluido {get;set;} 

           public ListaTarefas(Guid Id, string tarefa, bool concluido)
        {
            this.Id = Id;
            this.tarefa = tarefa;
            this.concluido = concluido;
        }
    }
}