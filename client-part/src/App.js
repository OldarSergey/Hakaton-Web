import './App.css';
import { useState,useEffect } from "react";
import Card from 'react-bootstrap/Card';
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Container from 'react-bootstrap/esm/Container';
import Project from './components/Project';
import HeaderLine from './components/HeaderLine';
import axios from 'axios';
import AddProject from './components/AddProject';

function App() {
 
  
  const [boards, setBoards] = useState([]);
  
  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await axios.get('https://localhost:7182/api/Status');
        console.log(response.data);
        const transformedData = response.data.map(status => ({
          id: status.id,
          name: status.name,
          description: status.description,
          projects: status.projects.map(project => ({
            id: project.id,
            isDeleted: project.isDeleted,
            name: project.name,
            description: project.description,
            deadLine: project.deadLine,
            categoryId: project.categoryId,
            statusId: project.statusId,
            priorityId: project.priorityId,
            chatId: project.chatId,
            category: project.category,
            status: project.status,
            priority: project.priority,
            chat: project.chat,
            users: project.users,
            tasks: project.tasks,
          }))
        }));
        setBoards(transformedData);
      } catch (error) {
        console.error('Ошибка при получении данных:', error);
      }
    };
  
    fetchProjects();
  }, []);
  
  

const [draggedItem, setDraggedItem] = useState(null);

function dragEndHandler(e) {
  e.target.style.boxShadow = 'none';
}

const updateProjects = () => {
  const fetchProjects = async () => {
    try {
      const response = await axios.get('https://localhost:7182/api/Status');
      console.log(response.data);

      // Преобразование данных, если необходимо, может быть дополнено здесь
      // Например, вы можете обработать данные и отфильтровать их, если нужно

      const transformedData = response.data.map(status => ({
        id: status.id,
        name: status.name,
        description: status.description,
        projects: status.projects.map(project => ({
          id: project.id,
          isDeleted: project.isDeleted,
          name: project.name,
          description: project.description,
          deadLine: project.deadLine,
          categoryId: project.categoryId,
          statusId: project.statusId,
          priorityId: project.priorityId,
          chatId: project.chatId,
          category: project.category,
          status: project.status,
          priority: project.priority,
          chat: project.chat,
          users: project.users,
          tasks: project.tasks,
        }))
      }));

      // Обновление состояния `boards` с обновленными данными
      setBoards(transformedData);
    } catch (error) {
      console.error('Ошибка при получении данных:', error);
    }
  };

  // Вызов функции fetchProjects для получения и обновления данных
  fetchProjects();
};


function dragOverHandler(e, board) {
  e.preventDefault();
  
  e.dataTransfer.dropEffect = "move";
}

function dragStartHandler(e, board, project) {
  e.dataTransfer.setData("project", JSON.stringify(project));
  e.dataTransfer.setData("sourceBoard", JSON.stringify(board));
}

function dropHandler(e, targetBoard) {
  e.preventDefault();
  const sourceBoard = JSON.parse(e.dataTransfer.getData("sourceBoard"));
  const sourceProject = JSON.parse(e.dataTransfer.getData("project"));


  if (sourceBoard.id === targetBoard.id) {
    return;
  }

  axios.put(`https://localhost:7182/api/Status/${sourceProject.id}/${targetBoard.id}`)
  .then((response) => {
    console.log("Обновление прошло успешно");
  })  
  .catch((error) => {
    console.error('Ошибка при обновлении статуса проекта:', error);
  });

  const updatedBoards = [...boards];
  const sourceBoardIndex = updatedBoards.findIndex((board) => board.id === sourceBoard.id);
  const targetBoardIndex = updatedBoards.findIndex((board) => board.id === targetBoard.id);


  const sourceProjectIndex = updatedBoards[sourceBoardIndex].projects.findIndex((project) => project.id === sourceProject.id);

  if (sourceProjectIndex !== -1) {
    updatedBoards[sourceBoardIndex].projects.splice(sourceProjectIndex, 1);
    updatedBoards[targetBoardIndex].projects.push(sourceProject);
  }

  setBoards(updatedBoards);
}

  return (
    <div className="App">
      
       <HeaderLine></HeaderLine>
       <AddProject updateProjects={updateProjects} />
     
      <Container style={{marginTop:'2%'}}>
        <Row>
        {boards.map((board) => (
            <Col key={board.id}>
              <Card
                onDragOver={(e) => dragOverHandler(e, board)}
                onDrop={(e) => dropHandler(e, board)}
                className="card card-header bg-light"
              >
                <div className='board-margin'>
                  {board.name}
                </div>
                {board.projects.map((project) => (
                  <div
                    key={project.id}
                    onDragStart={(e) => dragStartHandler(e, board, project)}
                    onDragEnd={(e) => dragEndHandler(e)}
                    draggable={true}
                    className="item item-margin"
                  >
                    <Project name={project.name}description={project.description} deadLine={project.deadLine} id={project.priorityId}></Project>
                  </div>
                )
                )}
              </Card>
            </Col>
          ))}
        </Row>
      </Container>
    </div>
  );
}        

export default App;
