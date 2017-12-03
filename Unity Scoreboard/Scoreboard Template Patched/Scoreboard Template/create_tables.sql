CREATE TABLE users (
	id int NOT NULL AUTO_INCREMENT,
	username varchar(12),
	password varchar(12),
    PRIMARY KEY (id)
);

CREATE TABLE leaderboard (
	userId int,
	score int,
	sDate date
);

CREATE TABLE testtable (
	testId int
);

INSERT INTO testtable (testId)
VALUES (1);

INSERT INTO users (username, password)
VALUES ('Maverick', 'password1234');
INSERT INTO users (username, password)
VALUES ('Andrews', 'nightmares');
INSERT INTO users (username, password)
VALUES ('Darcy', 'iamthebest');
INSERT INTO users (username, password)
VALUES ('Chris', 'abc123');
INSERT INTO users (username, password)
VALUES ('Nate', 'NateTheGreat');
INSERT INTO users (username, password)
VALUES ('Rambo', 'spot1990');
INSERT INTO users (username, password)
VALUES ('Yuto', ',&B$/zh5$yPX');
INSERT INTO users (username, password)
VALUES ('Kim', '9+X*JxGC{5D9');
INSERT INTO users (username, password)
VALUES ('Loreen', 'xgJA[Vv{@2x}');

INSERT INTO leaderboard (userId, score, sDate)
VALUES (1, 480, '2017-04-22');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (1, 550, '2017-04-24');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (2, 300, '2016-11-04');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (2, 120, '2016-11-04');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (3, 250, '2016-12-14');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (3, 200, '2016-12-14');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (4, 100, '2016-05-29');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (4, 180, '2016-05-29');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (5, 320, '2016-04-9');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (5, 400, '2016-04-10');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (6, 380, '2016-11-20');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (6, 310, '2016-11-20');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (7, 310, '2016-06-11');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (7, 90, '2016-06-11');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (8, 90, '2017-02-05');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (8, 200, '2017-02-05');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (9, 440, '2017-04-15');
INSERT INTO leaderboard (userId, score, sDate)
VALUES (9, 270, '2017-04-15');