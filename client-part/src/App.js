import './App.css';

import { useState,useEffect } from "react";
import Card from 'react-bootstrap/Card';
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Container from 'react-bootstrap/esm/Container';
import Project from './components/Project';
import HeaderLine from './components/HeaderLine';
import axios from 'axios';

function App() {
 
  
  const [boards, setBoards] = useState([]);
  
  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await axios.get('https://localhost:7182/api/Project');
        console.log(response.data);
          const transformedData = response.data.map(project => ({
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



function dragOverHandler(e, board) {
  e.preventDefault();
  if (e.target.className === 'card') {
    e.target.style.boxShadow = '0 4px 3px gray';
  }
}

function dragStartHandler(e, board, item) {
  setDraggedItem({ board, item });
}

function dropHandler(e, targetBoard) {
  e.preventDefault();
  const sourceBoard = draggedItem.board;
  const sourceItem = draggedItem.item;

  const updatedBoards = [...boards];
  const sourceBoardIndex = updatedBoards.findIndex((board) => board.id === sourceBoard.id);
  const targetBoardIndex = updatedBoards.findIndex((board) => board.id === targetBoard.id);

  const sourceItemIndex = updatedBoards[sourceBoardIndex].items.findIndex((item) => item.id === sourceItem.id);

  updatedBoards[sourceBoardIndex].items.splice(sourceItemIndex, 1);
  updatedBoards[targetBoardIndex].items.push(sourceItem);

  setBoards(updatedBoards);

  e.target.style.boxShadow = 'none';
  setDraggedItem(null);
}

  return (
    <div className="App">
      
       <HeaderLine></HeaderLine>
      
     
      <Container>
        <Row>
        {boards.map((board) => (
            <Col key={board.id}>
              <Card
                onDragOver={(e) => dragOverHandler(e, board)}
                onDrop={(e) => dropHandler(e, board)}
                className="card"
              >
                <div className='board-margin'>
                  {board.name}
                </div>
                {board.items.map((item) => (
                  <div
                    key={item.id}
                    onDragStart={(e) => dragStartHandler(e, board, item)}
                    onDragEnd={(e) => dragEndHandler(e)}
                    draggable={true}
                    className="item item-margin"
                  >
                    <Project name={item.name || "No Name"}></Project>
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
